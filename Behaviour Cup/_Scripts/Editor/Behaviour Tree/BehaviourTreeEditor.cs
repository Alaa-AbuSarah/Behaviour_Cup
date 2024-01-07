using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Callbacks;

namespace Behaviour_Cup
{
    public class BehaviourTreeEditor : EditorWindow
    {
        BehaviourTreeView treeView;
        InspectorView inspectorView;
        SerializedObject treeObject;

        [MenuItem("Behaviour Cup/Editor")]
        public static void OpenWindow()
        {
            BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
            wnd.titleContent = new GUIContent("Behaviour Cup");
        }

        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceId, int line)
        {
            if (Selection.activeObject is BehaviourTree)
            {
                OpenWindow();
                return true;
            }

            return false;
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(EditorHelper.FindPath("BehaviourTreeEditor", "VisualTreeAsset"));
            visualTree.CloneTree(root);

            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(EditorHelper.FindPath("BehaviourTreeEditor", "StyleSheet"));
            root.styleSheets.Add(styleSheet);

            treeView = root.Q<BehaviourTreeView>();
            inspectorView = root.Q<InspectorView>();

            treeView.OnNodeSelected = OnNodeSelectionChanged;

            root.Q<BehaviourTreeView>("BehaviourTreeView").window = this;

            OnSelectionChange();
        }

        private void OnEnable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }

        private void OnPlayModeStateChanged(PlayModeStateChange obj)
        {
            switch (obj)
            {
                case PlayModeStateChange.EnteredEditMode:
                    OnSelectionChange();
                    break;
                case PlayModeStateChange.EnteredPlayMode:
                    OnSelectionChange();
                    break;
            }
        }

        private void OnSelectionChange()
        {
            BehaviourTree tree = Selection.activeObject as BehaviourTree;

            if (!tree)
                if (Selection.activeGameObject)
                {
                    BehaviourTreeRunner runner = Selection.activeGameObject.GetComponent<BehaviourTreeRunner>();
                    if (runner) tree = runner.tree;
                }

            if (Application.isPlaying)
            {
                if (tree) try
                    {
                        treeView.PopulateView(tree);
                    }
                    catch { }
            }
            else
            {
                if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
                    try
                    {
                        treeView.PopulateView(tree);
                    }
                    catch { }
            }

            if (tree != null)
                treeObject = new SerializedObject(tree);
        }

        private void OnNodeSelectionChanged(NodeView node) => inspectorView.UpdateSelection(node);

        private void OnInspectorUpdate()
        {
            treeView?.UpdateNodeStates();
        }
    }
}