using UnityEngine;
using UnityEngine.UI;

namespace Die {

    public class NextLevelButton : MonoBehaviour {

        Button button;

        void Start() {
            button = GetComponent<Button>();
        }

        public void Activate() {
            gameObject.SetActive(true);
        }

        public void Deactivate() {
            gameObject.SetActive(false);
        }
    }

}
