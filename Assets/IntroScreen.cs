using UnityEngine;

namespace Die {

    public class IntroScreen : MonoBehaviour {
        CanvasGroup canvasGroup;
        [SerializeField] Transform levelButtons;

        [SerializeField] LevelButton levelButtonPrefab;
        [SerializeField] LevelFiles levelFiles;

        private void Start() {
            canvasGroup = GetComponent<CanvasGroup>();
            foreach (string level in levelFiles.filenames) {
                LevelButton button = Instantiate(levelButtonPrefab, levelButtons);
                button.levelName = level.Replace(LevelManager.SAVE_FILE_SUFFIX, "");
            }
        }

        public void Hide() {
            canvasGroup.alpha = 0;
            gameObject.SetActive(false);
        }
    }

}
