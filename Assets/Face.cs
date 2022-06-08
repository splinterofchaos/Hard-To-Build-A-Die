using UnityEngine;

namespace Die {
    public class Face : GridActor {
        [SerializeField] MeshRenderer plateMesh;

        public FaceData data;

        public int number { get => data.number; }

        public void SetData(FaceData data) {
            this.data = data;
            plateMesh.material = data.material;
            name = data.name;
        }

        private void OnValidate() {
            if (data != null) {
                plateMesh.material = data.material;
            }
            Snap();
        }
    }

}
