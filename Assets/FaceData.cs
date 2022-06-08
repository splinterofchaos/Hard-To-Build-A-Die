using UnityEngine;



namespace Die {
    [CreateAssetMenu]
    public class FaceData : ScriptableObject {
        public Material material;
        [Range(1, 6)] public int number;
    }

}
