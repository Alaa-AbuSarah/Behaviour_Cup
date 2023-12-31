using UnityEngine;
using UnityEditor;

namespace Behaviour_Cup
{
    [CustomEditor(typeof(Node), true)]
    public class NodeEditor : Editor
    {
        Node node;

        private void OnEnable() => node = target as Node;
        Vector2 scrollPos;
        public override void OnInspectorGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            int space = 5;
            string description = node.Description(ref space);

            if (description != null)
            {
                GUIStyle style = new GUIStyle();
                style.richText = true;
                style.alignment = TextAnchor.UpperCenter;
                EditorGUILayout.LabelField($"<color>{description}</color>", style);

                EditorGUILayout.Space(space);
                GuiLine();
                EditorGUILayout.Space();
            }

            base.OnInspectorGUI();

            EditorGUILayout.EndScrollView();
        }

        private void GuiLine(int i_height = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, i_height);
            rect.height = i_height;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }
    }
}