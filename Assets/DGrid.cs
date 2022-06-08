using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Die {

    public class DGrid : MonoBehaviour {
        public Vector2Int size = new Vector2Int(10, 10);
        public float cellSize = 1;
        public float z;
        public Cell cellPrefab;

        public bool findGridActorsAtStart = false;

        Cell[,] cells = null;

        Dictionary<Vector2Int, GridActor> gridActors = new();

        [SerializeField] Transform cellRoot;

        public GridActor this[Vector2Int pos] {
            get {
                GridActor ga;
                return gridActors.TryGetValue(pos, out ga) ? ga : null;
            }
            set => gridActors[pos] = value;
        }

        public GridActor this[int x, int y] {
            get => this[new Vector2Int(x, y)];
            set => this[new Vector2Int(x, y)] = value;
        }

        private void Awake() {
            if (cells == null) CreateGrid();
        }

        private void Start() {
            if (findGridActorsAtStart) {
                gridActors = FindObjectsOfType<GridActor>()
                    .ToDictionary(ga => ga.gridPos);
            }
        }

        [ContextMenu("Log Grid Actors")]
        void EditorLogActors() {
            foreach (var (pos, actor) in gridActors) {
                Debug.Log($"({pos}) => {actor}");
            }
        }

        public void ClearGrid() {
            gridActors.Clear();
        }

        private void OnDrawGizmos() {
            foreach (Vector2Int pos in Positions()) {
                Gizmos.DrawCube(RelativeCellPosition(pos), new Vector3(1, .1f, 1));
            }
        }

        public IEnumerable<Vector2Int> Positions() {
            for (int x = 0; x < size.x; x++) {
                for (int y = 0; y < size.y; y++) {
                    yield return new Vector2Int(x, y);
                }
            }
        }

        Vector3 RelativeCellPosition(Vector2Int gridPos) {
            Vector3 pos = new Vector3(gridPos.x, 0, gridPos.y) * cellSize;
            pos.y = z;
            return pos;
        }

        public Vector2Int WorldToGridPos(Vector3 worldPos) => new Vector2Int {
            x = Mathf.RoundToInt(worldPos.x),
            y = Mathf.RoundToInt(worldPos.z)
        };

        void CreateGrid() {
            if (cells != null) return;
            cells = new Cell[size.x, size.y];
            foreach (Vector2Int pos in Positions()) {
                cells[pos.x, pos.y] = Instantiate(
                    cellPrefab, RelativeCellPosition(pos), Quaternion.identity,
                    cellRoot);
            }
        }
    }

}
