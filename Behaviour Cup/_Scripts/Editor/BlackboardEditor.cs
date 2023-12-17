using UnityEngine;
using UnityEditor;

namespace Behaviour_Cup
{
    [CustomEditor(typeof(Blackboard))]
    public class BlackboardEditor : Editor
    {
        private int selected = 0;
        private string[] options = new string[]
        {
            " ", "Component","string","int","float","Vector2","Vector3","Color","Gradient","bool","Sprite"
        };
        private Blackboard blackboard;

        private void OnEnable() => blackboard = target as Blackboard;

        public override void OnInspectorGUI()
        {
            if (blackboard.components.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Component");

                for (int i = 0; i < blackboard.components.Count; i++)
                    DataComponentFiled(blackboard.components[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.strings.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("String");

                for (int i = 0; i < blackboard.strings.Count; i++)
                    DataStringFiled(blackboard.strings[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.ints.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Int");

                for (int i = 0; i < blackboard.ints.Count; i++)
                    DataIntFiled(blackboard.ints[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.floats.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Float");

                for (int i = 0; i < blackboard.floats.Count; i++)
                    DataFloatFiled(blackboard.floats[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.vector2s.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Vector2");

                for (int i = 0; i < blackboard.vector2s.Count; i++)
                    DataVector2Filed(blackboard.vector2s[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.vector3s.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Vector3");

                for (int i = 0; i < blackboard.vector3s.Count; i++)
                    DataVector3Filed(blackboard.vector3s[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.colors.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Color");

                for (int i = 0; i < blackboard.colors.Count; i++)
                    DataColorFiled(blackboard.colors[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.gradients.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Gradient");

                for (int i = 0; i < blackboard.gradients.Count; i++)
                    DataGradientFiled(blackboard.gradients[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.bools.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Bool");

                for (int i = 0; i < blackboard.bools.Count; i++)
                    DataBoolFiled(blackboard.bools[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            if (blackboard.sprites.Count != 0)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("Sprite");

                for (int i = 0; i < blackboard.sprites.Count; i++)
                    DataSpriteFiled(blackboard.sprites[i]);

                EditorGUILayout.Space(10);
                GuiLine();
            }

            EditorGUILayout.Space(15);

            EditorGUILayout.BeginHorizontal();

            selected = EditorGUILayout.Popup(selected, options);
            if (GUILayout.Button("Add"))
            {
                switch (selected)
                {
                    case 1:
                        blackboard.components.Add(new DataEntitiy<Component>("Key", null));
                        break;
                    case 2:
                        blackboard.strings.Add(new DataEntitiy<string>("Key", ""));
                        break;
                    case 3:
                        blackboard.ints.Add(new DataEntitiy<int>("Key", 0));
                        break;
                    case 4:
                        blackboard.floats.Add(new DataEntitiy<float>("Key", 0));
                        break;
                    case 5:
                        blackboard.vector2s.Add(new DataEntitiy<Vector2>("Key", Vector2.zero));
                        break;
                    case 6:
                        blackboard.vector3s.Add(new DataEntitiy<Vector3>("Key", Vector3.zero));
                        break;
                    case 7:
                        blackboard.colors.Add(new DataEntitiy<Color>("Key", Color.white));
                        break;
                    case 8:
                        blackboard.gradients.Add(new DataEntitiy<Gradient>("Key", new Gradient()));
                        break;
                    case 9:
                        blackboard.bools.Add(new DataEntitiy<bool>("Key", false));
                        break;
                    case 10:
                        blackboard.sprites.Add(new DataEntitiy<Sprite>("Key", null));
                        break;
                }
            }

            EditorGUILayout.EndHorizontal();

            if (EditorGUI.EndChangeCheck()) Undo.RecordObject(blackboard, "Blackboard (Edited)");

            serializedObject.ApplyModifiedProperties();
        }

        private void GuiLine(int height = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, height);
            rect.height = height;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }

        private void DataComponentFiled(DataEntitiy<Component> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.ObjectField(data.value, typeof(Component), true) as Component;

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.components.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataFloatFiled(DataEntitiy<float> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.FloatField(data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.floats.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataIntFiled(DataEntitiy<int> data)
        {
            EditorGUILayout.BeginHorizontal();
            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.IntField(data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))

                blackboard.ints.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataStringFiled(DataEntitiy<string> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.TextField(data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.strings.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataVector2Filed(DataEntitiy<Vector2> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.Vector2Field("", data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.vector2s.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataVector3Filed(DataEntitiy<Vector3> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.Vector3Field("", data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.vector3s.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataColorFiled(DataEntitiy<Color> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.ColorField(data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.colors.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataBoolFiled(DataEntitiy<bool> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.Toggle(data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.bools.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataGradientFiled(DataEntitiy<Gradient> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.GradientField(data.value);

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.gradients.Remove(data);

            EditorGUILayout.EndHorizontal();
        }

        private void DataSpriteFiled(DataEntitiy<Sprite> data)
        {
            EditorGUILayout.BeginHorizontal();

            data.key = EditorGUILayout.TextField(data.key);
            data.value = EditorGUILayout.ObjectField(data.value, typeof(Sprite), true) as Sprite;

            EditorGUILayout.Space();

            if (GUILayout.Button("X"))
                blackboard.sprites.Remove(data);

            EditorGUILayout.EndHorizontal();
        }
    }
}