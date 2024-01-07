using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEditor.Compilation;

namespace Behaviour_Cup
{
    [CustomEditor(typeof(Behaviour_Cup.Blackboard))]
    public class BlackboardEditor : Editor
    {
        public List<DataEntitiyListData> data = new List<DataEntitiyListData>
        {
            new DataEntitiyListData(typeof(GameObject),"gameObjects","GameObject"),
            new DataEntitiyListData(typeof(GameObject[]),"list_GameObjects","List-GameObject", valueLabel: true, layout : Layout.Vertical),
            new DataEntitiyListData(typeof(Transform),"transforms","Transform"),
            new DataEntitiyListData(typeof(Transform[]),"list_transforms","List_Transform",valueLabel: true, layout : Layout.Vertical),
            new DataEntitiyListData(typeof(Component),"components","Component"),
            new DataEntitiyListData(typeof(Component[]),"list_components","List_Component",valueLabel: true, layout : Layout.Vertical),
            new DataEntitiyListData(typeof(string),"strings","string"),
            new DataEntitiyListData(typeof(int),"ints","int"),
            new DataEntitiyListData(typeof(float),"floats","float"),
            new DataEntitiyListData(typeof(Vector2),"vector2s","Vector2"),
            new DataEntitiyListData(typeof(Vector3),"vector3s","Vector3"),
            new DataEntitiyListData(typeof(Color),"colors","Color"),
            new DataEntitiyListData(typeof(Gradient),"gradients","Gradient"),
            new DataEntitiyListData(typeof(bool),"bools","bool"),
            new DataEntitiyListData(typeof(Sprite),"sprites","Sprite"),
            new DataEntitiyListData(typeof(AnimationCurve),"curves","AnimationCurve"),
            new DataEntitiyListData(typeof(Material),"material","Material"),
            new DataEntitiyListData(typeof(Quaternion),"quaternions","Quaternion"),
            new DataEntitiyListData(typeof(Vector2Int),"vector2sInt","Vector2Int"),
            new DataEntitiyListData(typeof(Vector3Int),"vector3sInt","Vector3Int"),
            new DataEntitiyListData(typeof(Vector4),"vector4s","Vector4",layout:Layout.Vertical,valueLabel: true),
        };

        private List<string> options = new List<string>();
        private int selected = 0;
        private Blackboard blackboard;
        private bool typeWarning = false;

        private void OnEnable() => blackboard = target as Blackboard;

        public override void OnInspectorGUI()
        {
            data.ForEach(d =>
            {
                DrawList(d);
                options.Add(d.label);
            });

            EditorGUILayout.Space(15);

            EditorGUILayout.BeginHorizontal();
            selected = EditorGUILayout.Popup(selected, options.ToArray());

            if (GUILayout.Button("Add"))
            {
                SerializedProperty list = serializedObject.FindProperty($"_{data[selected].listName}");

                if (list != null) list.arraySize++;
                //else UpdateTypes();
            }

            if (GUILayout.Button("Update Types")) UpdateTypes();

            EditorGUILayout.EndHorizontal();

            if (EditorGUI.EndChangeCheck()) Undo.RecordObject(blackboard, "Blackboard (Edited)");

            serializedObject.ApplyModifiedProperties();
        }

        private void GuiLine(float height = 1f, float a = 1f)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, height);
            rect.height = height;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, a));
        }

        /// <summary>
        /// "DataEntitiy" list
        /// </summary>
        /// <param name="dataEntitiyList">The target data list</param>
        private void DrawList(DataEntitiyListData dataEntitiyList)
        {
            SerializedProperty list = serializedObject.FindProperty($"_{dataEntitiyList.listName}");

            if (list == null) return;

            if (list.arraySize != 0)
            {
                EditorGUILayout.Space(10);
                var boldtext = new GUIStyle(GUI.skin.label);
                boldtext.fontStyle = FontStyle.Bold;
                EditorGUILayout.LabelField(dataEntitiyList.label, boldtext);
                EditorGUILayout.Space(5);

                for (int i = 0; i < list.arraySize; i++)
                {
                    bool deleted = false;

                    SerializedProperty key = list.GetArrayElementAtIndex(i).FindPropertyRelative("key");
                    SerializedProperty value = list.GetArrayElementAtIndex(i).FindPropertyRelative("value");

                    switch (dataEntitiyList.layout)
                    {
                        case Layout.Horizontal:

                            EditorGUILayout.BeginHorizontal();

                            EditorGUILayout.PropertyField(key, new GUIContent(dataEntitiyList.keyLabel ? "Key" : ""));
                            try
                            {
                                EditorGUILayout.PropertyField(value, new GUIContent(dataEntitiyList.valueLabel ? "Value" : ""));
                            }
                            catch
                            {
                                if (!typeWarning)
                                {
                                    Debug.LogWarning($"Can Not draw {dataEntitiyList.type.ToString()}");
                                    typeWarning = true;
                                }
                            }

                            if (GUILayout.Button("X")) list.DeleteArrayElementAtIndex(i);

                            EditorGUILayout.EndHorizontal();

                            break;

                        case Layout.Vertical:

                            EditorGUILayout.BeginHorizontal();

                            EditorGUILayout.PropertyField(key, new GUIContent(dataEntitiyList.keyLabel ? "Key" : ""));

                            if (GUILayout.Button("X"))
                            {
                                list.DeleteArrayElementAtIndex(i);
                                deleted = true;
                            }

                            EditorGUILayout.EndHorizontal();

                            if (!deleted) EditorGUILayout.PropertyField(value, new GUIContent(dataEntitiyList.valueLabel ? "Value" : ""));

                            break;
                    }

                    if (i != list.arraySize - 1)
                    {
                        EditorGUILayout.Space(dataEntitiyList.spaces);
                        GuiLine(a: 0.25f);
                        EditorGUILayout.Space(dataEntitiyList.spaces);
                    }
                }

                EditorGUILayout.Space(10);
                GuiLine();
            }
        }

        private void UpdateTypes()
        {
            bool can = true;

            data.ForEach(d =>
            {
                if (d.type.ToString().Contains("System.Collections.Generic")) 
                {
                    Debug.LogError($"No support for Collections types on {d.listName}");
                    can = false;
                }

                if (string.IsNullOrEmpty(d.listName) || char.IsDigit(d.listName[0]))
                {
                    Debug.LogError($"The list name should not be Empty and start whit later on {d.listName}");
                    can = false;
                }

                data.ForEach(d2 =>
                {
                    if (d2 != d & d2.listName == d.listName)
                    {
                        Debug.LogError($"List name for every type should be younique on {d.listName}");
                        can = false;
                    }
                });

                data.ForEach(d2 =>
                {
                    if (d2 != d & d2.label == d.label)
                    {
                        Debug.LogError($"List Label for every type should be younique");
                        can = false;
                    }
                });

                SerializedProperty list = serializedObject.FindProperty($"_{d.listName}");
                if (list == null && can) EditorHelper.OverrideBlackboard(d);
            });

            if (can) CompilationPipeline.RequestScriptCompilation();
        }
    }
}