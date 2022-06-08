using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Die {
    public class GridActor : MonoBehaviour {
        public Vector2Int gridPos {
            get => new Vector2Int(
                Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.z));
            set => transform.position = new Vector3(
                value.x, transform.position.y, value.y);
        }

        private void OnDrawGizmosSelected() {
            Snap();
        }

        public void Snap() { gridPos = gridPos; }
    }

}
