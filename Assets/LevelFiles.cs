using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Die {

    [CreateAssetMenu]
    public class LevelFiles : ScriptableObject {
        public List<string> filenames;

#if UNITY_EDITOR
        [ContextMenu("Auto generate")]
        void AutoGenerate() {
            filenames = Directory.GetFiles(LevelManager.LevelDirectory())
                .Where(name => name.EndsWith(LevelManager.SAVE_FILE_SUFFIX))
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }
#endif
    }

}
