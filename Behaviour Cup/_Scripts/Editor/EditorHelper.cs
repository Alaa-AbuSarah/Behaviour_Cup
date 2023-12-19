using UnityEditor;

namespace Behaviour_Cup
{
    public static class EditorHelper
    {
        public static string FindPath(string name, string type)
        {
            string[] paths = AssetDatabase.FindAssets($"{name} t:{type}");
            return AssetDatabase.GUIDToAssetPath(paths[0]);
        }
    }
}