using UnityEngine;
using UnityEngine.UI;

namespace Die {

    public class LevelButton : MonoBehaviour {
        [SerializeField] TMPro.TextMeshProUGUI buttonText;

        public string levelName {
            get => buttonText.text;
            set => buttonText.text = value;
        }

        public void LoadLevel() {
            LevelManager.Instance().LoadLevel(buttonText.text);
        }
    }

}
