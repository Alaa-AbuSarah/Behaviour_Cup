using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace Behaviour_Cup
{
    public static class EditorHelper
    {
        public static string FindPath(string name, string type)
        {
            string[] paths = AssetDatabase.FindAssets($"{name} t:{type}");
            return AssetDatabase.GUIDToAssetPath(paths[0]);
        }

        public static string FindPath(string name)
        {
            string[] paths = AssetDatabase.FindAssets($"{name}");
            return AssetDatabase.GUIDToAssetPath(paths[0]);
        }

        public static string FindCSPath(string name, string file)
        {
            string[] paths = AssetDatabase.FindAssets($"{name}");
            foreach (var path in paths)
            {
                string p = AssetDatabase.GUIDToAssetPath(path);
                if (p.Contains(file) && p.Contains(".cs")) return p;
            }

            return "";
        }

        public static string BlackboardAPI(DataEntitiyListData data)
        {
            string value = "";

            using (var reader = new StreamReader(FindPath("BlackboardAPI")))
            {
                value = reader.ReadToEnd();
                value = value.Replace("[Type]", data.type.ToString());
                value = value.Replace("[ListName]", data.listName);

                reader.Close();
            }

            return value;
        }

        public static string BlackboardHave(DataEntitiyListData data)
        {
            string value = "";

            using (var reader = new StreamReader(FindPath("BlackboardHave")))
            {
                value = reader.ReadToEnd();
                value = value.Replace("[ListName]", data.listName);

                reader.Close();
            }

            return value;
        }

        public static void OverrideBlackboard(DataEntitiyListData data)
        {
            string oldText = "";

            using (var reader = new StreamReader(FindCSPath("Blackboard", "Runtime")))
            {
                oldText = reader.ReadToEnd();
                reader.Close();
            }

            using (var writer = new StreamWriter(FindCSPath("Blackboard", "Runtime"), false))
            {
                string newText = oldText;
                newText = newText.Replace("//API Line", $"{ BlackboardAPI(data)}\n\n//API Line");
                newText = newText.Replace("//Have Line", $"{ BlackboardHave(data)}\n//Have Line");
                Debug.Log(newText);

                writer.WriteLine(newText);

                writer.Close();
            }
        }
    }
}