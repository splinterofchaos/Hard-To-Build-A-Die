using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Die {

    public class Die : GridActor {
        [SerializeField] GameObject cube;
        [SerializeField] NewControls controls;

        public DGrid grid;

        public float turnTime = 0.5f;

        bool busy;

        [SerializeField] Face faceUnderMe = null;

        Face[] attachedFaces = new Face[6];

        [SerializeField] Vector2 inputMotion;
        [SerializeField] Vector2 lastInputAxis;

        [SerializeField] List<AudioClip> dieHitAudioClips;
        [SerializeField] List<AudioClip> snapAudioClips;
        AudioSource audioSource;

        private void Start() {
            for (int i = 0; i < 6; i++) attachedFaces[i] = null;
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable() {
            controls = new NewControls();
            controls.Enable();
            controls.Rolling.UpDown.performed += UpDownStart;
            controls.Rolling.UpDown.canceled += UpDownEnd;
            controls.Rolling.LeftRight.performed += LeftRightStart;
            controls.Rolling.LeftRight.canceled += LeftRightEnd;
        }

        private void OnDisable() {
            controls.Disable();
            controls.Rolling.UpDown.performed -= UpDownStart;
            controls.Rolling.LeftRight.performed -= LeftRightStart;
            controls.Rolling.LeftRight.performed -= LeftRightStart;
            controls.Rolling.LeftRight.canceled -= LeftRightEnd;
            
        }

        int FreeFaceIndex() {
            for (int i = 0; i < 6; i++) if (attachedFaces[i] == null) return i;
            return -1;
        }

        int NumAttachedFaces() =>
            attachedFaces.Where(f => f != null).Count();

        Vector3 Relative(Face f) => cube.transform.position -
                                    f.transform.position;

        // Why not use Mathf.Approximately()? It's a little too precise to
        // account for rounding error in our case.
        static bool Approximately(float a, float b) {
            return Mathf.Abs(a - b) < 0.00001f;
        }

        bool IsOverlapping(Face a, Face b) =>  Approximately(
            Vector3.Distance(Relative(a), Relative(b)), 0);

        bool IsOpposing(Face a, Face b) => Approximately(
            Vector3.Dot(Relative(a).normalized, Relative(b).normalized), -1);

        enum LandResult { Ok, GoBack };

        void AttachFaceUnderMe() {
            faceUnderMe.transform.parent = cube.transform;
            attachedFaces[FreeFaceIndex()] = faceUnderMe;
            faceUnderMe = null;

            PlayRandomClip(snapAudioClips);

            if (NumAttachedFaces() == 6) LevelManager.Instance().OnVictory();
        }

        void PlayRandomClip(List<AudioClip> clips) {
            if (clips.Count == 0) return;
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Count - 1)]);
        }

        LandResult OnLand() {
            if (faceUnderMe == null) {
                PlayRandomClip(dieHitAudioClips);
                return LandResult.Ok;
            }
            if (NumAttachedFaces() == 6) return LandResult.GoBack;
            if (attachedFaces.Any(f => f != null &&
                                       IsOverlapping(f, faceUnderMe))) {
                return LandResult.GoBack;
            }

            foreach (Face f in attachedFaces.Where(f => f != null)) {
                if (IsOpposing(faceUnderMe, f)) {
                    if (f.number + faceUnderMe.number == 7) {
                        AttachFaceUnderMe();
                        return LandResult.Ok;
                    } else {
                        return LandResult.GoBack;
                    }
                } else if (f.number + faceUnderMe.number == 7) {
                    return LandResult.GoBack;
                }
            }

            AttachFaceUnderMe();
            return LandResult.Ok;
        }

        // TODO: This is aweful, and yet it works.
        IEnumerator Flip(Vector3 eulers, Vector3 motion) {
            if (busy) yield break;

            busy = true;

            float timeStarted = Time.time;
            Quaternion startingRot = cube.transform.rotation;
            Vector3 startingPos = transform.position;
            Vector3 targetPos = startingPos + motion;
            float largestRise = 0.2f;
            while (Time.time - timeStarted < turnTime) {
                float t = (Time.time - timeStarted) / turnTime;
                cube.transform.rotation = startingRot;
                cube.transform.Rotate(eulers, 90 * t, Space.World);

                float heightAngle = Mathf.Lerp(0, Mathf.PI, t);
                transform.position =
                    Vector3.Lerp(startingPos, targetPos, t) +
                    Vector3.up * (Mathf.Sin(Mathf.PI * t) * largestRise);

                yield return new WaitForEndOfFrame();
            }
            cube.transform.rotation = startingRot;
            cube.transform.Rotate(eulers, 90, Space.World);
            transform.position = targetPos;

            busy = false;

            if (OnLand() == LandResult.GoBack) {
                StartCoroutine(Flip(-eulers, -motion));
            } else if (!Mathf.Approximately(inputMotion.sqrMagnitude, 0)) {
                DoInputMove();
            }
        }

        private void DoInputMove() {
            Vector2 newMotion = inputMotion;
            if (inputMotion == Vector2.zero) return;
            if (inputMotion.x != 0 && inputMotion.y != 0) newMotion = lastInputAxis;
            Move(newMotion.x, newMotion.y);
        }

        void Move(float xDirection, float yDirection) {
            Vector3 direction = Vector3.right * xDirection +
                                Vector3.back * yDirection;

            Vector3 landingSpot = transform.position + direction;
            if (landingSpot.x < 0 || landingSpot.z < 0 ||
                landingSpot.x >= grid.size.x || landingSpot.z >= grid.size.y) {
                return;
            }

            GridActor gridActor = grid[grid.WorldToGridPos(landingSpot)];
            if (gridActor != null && gridActor as Wall) return;

            Vector3 eulers = Vector3.back * xDirection +
                             Vector3.left * yDirection;
            StartCoroutine(Flip(eulers, direction));
        }

        void SetInputMotion(int axis, float value, bool starting) {
            inputMotion[axis] = value;
            if (starting) {
                lastInputAxis = Vector2.zero;
                lastInputAxis[axis] = value;
            }

            if (starting && !busy) DoInputMove();
        }

        void UpDownStart(CallbackContext ctx) =>
            SetInputMotion(1, ctx.ReadValue<float>(), true);

        void UpDownEnd(CallbackContext ctx) =>
            SetInputMotion(1, 0, false);

        void LeftRightStart(CallbackContext ctx) =>
            SetInputMotion(0, ctx.ReadValue<float>(), true);

        void LeftRightEnd(CallbackContext ctx) =>
            SetInputMotion(0, 0, false);

        private void OnTriggerEnter(Collider other) {
            Face newFaceUnderMe = other.gameObject.GetComponent<Face>();
            if (newFaceUnderMe != null) {
                faceUnderMe = newFaceUnderMe;
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.gameObject.GetComponent<Face>() == faceUnderMe) {
                faceUnderMe = null;
            }
        }
    }
}
