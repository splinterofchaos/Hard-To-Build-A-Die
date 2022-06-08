using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

namespace Die {

    public class LevelManager : MonoBehaviour {
        public const string SAVE_FILE_SUFFIX = ".dielevel";
        static LevelManager instance = null;

        [SerializeField] LevelFiles levelFiles;

        string loadedLevel = null;
        public LevelData levelData;

        public List<Face> faces;
        public Die die;

        [SerializeField] DGrid grid;
        [SerializeField] Die diePrefab;
        [SerializeField] Face facePrefab;
        [SerializeField] Wall wallPrefab;
        [SerializeField] DGrid gridPrefab;
        [SerializeField] FaceData[] faceData = new FaceData[6];

        List<GridActor> gridActors = new();

        [SerializeField] IntroScreen introScreen;
        [SerializeField] NextLevelButton nextLevelButton;

        private void Awake() {
            instance = this;
        }

        private void Start() {
            instance = this;

        }

        public static LevelManager Instance() {
            return instance;
        }

        private void OnEnable() {
            if (instance == null) instance = this;
        }

        private void OnDisable() {
            if (instance == this) instance = null;
        }

        public void OnVictory() {
            int i = LevelIndex();
            if (i >= 0 && i < levelFiles.filenames.Count - 1) nextLevelButton.Activate();
        }

        public void Quit() {
            Application.Quit(0);
        }

#if UNITY_EDITOR
        [ContextMenu("Build Data")]
        public void EditorBuildLevelData() {
            levelData.faces = FindObjectsOfType<Face>()
                .Select(f => new LevelData.Face { number = f.number,
                                                  pos = f.gridPos })
                .ToList();
            if (levelData.faces.Count == 0) {
                Debug.Log("Failed to find any Faces in the level.");
            }

            Die die = FindObjectOfType<Die>();
            if (die == null) {
                Debug.Log("Failed to find Die.");
            } else {
                levelData.startingPosition = die.gridPos;
            }

            levelData.walls = FindObjectsOfType<Wall>()
                .Select(w => w.gridPos)
                .ToList();
        }
#endif

        public static string LevelDirectory() {
            return Path.Combine(Application.streamingAssetsPath, "Levels");
        }

        string LevelFilename(string levelName) => levelName + SAVE_FILE_SUFFIX;

#if UNITY_EDITOR
        [ContextMenu("Save Level")]
        public bool EditorSaveLevel() {
            EditorBuildLevelData();
            string dir = LevelDirectory();
            string filename = LevelFilename(levelData.name);

            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            string path = Path.Combine(dir, filename);
            Debug.Log("Saving level to " + path);

            File.WriteAllText(path, JsonUtility.ToJson(levelData));

            levelFiles.filenames.Add(levelData.name);

            return true;
        }
#endif

        T SpawnGridActor<T>(T prefab, Vector2Int pos) where T : GridActor {
            T actor = Instantiate(prefab, grid.transform);
            actor.gridPos = pos;
            grid[pos] = actor;
            gridActors.Add(actor);
            return actor;
        }

#if UNITY_EDITOR
        [ContextMenu("Load Level")]
        public bool EditorLoadLevel() {
            grid.ClearGrid();
            GridActor[] inLevelActors = FindObjectsOfType<GridActor>();
            foreach (GridActor a in inLevelActors.Where(a => a != null)) {
                DestroyImmediate(a.gameObject);
            }

            gridActors.Clear();

            return LoadLevel(levelData.name);
        }
#endif

        public void LoadNextLevel() {
            int i = LevelIndex();
            Debug.Log("Found level index: " + i.ToString());
            if (i == -1) {
                Debug.Log($"Current level, \"{loadedLevel}\", not found");
                return;
            }

            if (i + 1 == levelFiles.filenames.Count) {
                Debug.Log("No more levels.");
                return;
            }

            LoadLevel(levelFiles.filenames[i + 1]);
        }

        private int LevelIndex() =>
            levelFiles.filenames.FindIndex(name => name == loadedLevel);

        public bool LoadLevel(string levelName) {
            if (grid == null) {
                grid = Instantiate(gridPrefab);
            }

            Debug.Log($"Loading {levelName}...");

            string fullFileName = Path.Combine(LevelDirectory(),
                                               LevelFilename(levelName));
            string strLevel = File.ReadAllText(fullFileName);

            if (strLevel == null) {
                Debug.Log("Level data not found");
                return false;
            }

            levelData = JsonUtility.FromJson<LevelData>(strLevel);

            if (levelData == null) {
                Debug.Log("Level data corrupted...");
                return false;
            }

            loadedLevel = levelName;

            if (introScreen != null) introScreen.Hide();

            foreach (GridActor ga in gridActors) {
                Destroy(ga.gameObject);
            }
            gridActors.Clear();

            foreach (LevelData.Face f in levelData.faces) {
                SpawnGridActor(facePrefab, f.pos)
                    .SetData(faceData[f.number - 1]);
            }

            foreach (Vector2Int wallPos in levelData.walls) {
                SpawnGridActor(wallPrefab, wallPos);
            }

            Die die = SpawnGridActor(diePrefab, levelData.startingPosition);
            die.grid = grid;

            return true;
        }
    }

}
