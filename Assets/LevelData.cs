using System.Collections.Generic;
using UnityEngine;

namespace Die {
    [System.Serializable]
    public class LevelData {
        public string name = "foo";
        public Vector2Int startingPosition;

        [System.Serializable]
        public struct Face { public Vector2Int pos; public int number; };

        public List<Face> faces;

        public List<Vector2Int> walls;
    }
}
