using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using System;
using System.Linq;
using UnityEngine;

namespace Behaviour_Cup
{
    public class BehaviourTreeView : GraphView
    {
        public Action<NodeView> OnNodeSelected;
        public EditorWindow window;

        private NodeSearch search;
        private BehaviourTree _tree;
        private MiniMap map;

        public new class UxmlFactory : UxmlFactory<BehaviourTreeView, GraphView.UxmlTraits> { }

        public BehaviourTreeView()
        {
            Insert(0, new GridBackground());

            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());

            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(EditorHelper.FindPath("BehaviourTreeEditor", "StyleSheet"));
            styleSheets.Add(styleSheet);

            Undo.undoRedoPerformed += OnUndoRedo;

            AddSearchWindow();
            GenerateMiniMap();
        }

        private void AddSearchWindow()
        {
            search = ScriptableObject.CreateInstance<NodeSearch>();
            search.Init(this);

            nodeCreationRequest = c => SearchWindow.Open(new SearchWindowContext(c.screenMousePosition), search);
        }

        private void OnUndoRedo()
        {
            PopulateView(_tree);
            AssetDatabase.SaveAssets();
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt) { }

        public void CreatNodeByName(string name, Vector2 position)
        {
            if (string.IsNullOrEmpty(name)) return;
            CreatNode(TypeCache.GetTypesDerivedFrom<Node>().Where(t => t.Name == name).ToList()[0], position);
        }

        private void CreatNode(Type type, Vector2 position)
        {
            Node node = _tree.CreateNode(type);
            node.position = contentViewContainer.WorldToLocal(position);
            CreateNodeView(node);
        }

        public void PopulateView(BehaviourTree tree)
        {
            _tree = tree;

            graphViewChanged -= OnGraphViewChanged;
            DeleteElements(graphElements);
            graphViewChanged += OnGraphViewChanged;

            if (_tree.rootNode == null)
            {
                _tree.rootNode = _tree.CreateNode(typeof(RootNode)) as RootNode;
                EditorUtility.SetDirty(_tree);
                AssetDatabase.SaveAssets();
            }

            //Create nodes view.
            tree.nodes.ForEach(n => CreateNodeView(n));

            //Create edges.
            tree.nodes.ForEach(n =>
            {
                var children = _tree.GetChildren(n);
                children.ForEach(c =>
                {
                    NodeView parentView = GetNodeByGuid(n.guid) as NodeView;
                    NodeView childView = GetNodeByGuid(c.guid) as NodeView;

                    Edge edge = parentView.output.ConnectTo(childView.input);
                    AddElement(edge);
                });
            });
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            return ports.ToList().Where(endPort =>
            endPort.direction != startPort.direction &&
            endPort.node != startPort.node).ToList();
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
        {
            if (graphViewChange.elementsToRemove != null)
            {
                graphViewChange.elementsToRemove.ForEach(e =>
                {
                    NodeView nodeView = e as NodeView;
                    if (nodeView != null)
                        _tree.DeleteNode(nodeView.node);

                    Edge edge = e as Edge;
                    if (edge != null)
                    {
                        NodeView parentView = edge.output.node as NodeView;
                        NodeView childView = edge.input.node as NodeView;
                        _tree.RemoveChild(parentView.node, childView.node);
                    }
                });
            }

            if (graphViewChange.edgesToCreate != null)
                graphViewChange.edgesToCreate.ForEach(edge =>
                {
                    NodeView parentView = edge.output.node as NodeView;
                    NodeView childView = edge.input.node as NodeView;
                    _tree.AddChild(parentView.node, childView.node);
                });

            if (graphViewChange.movedElements != null)
                nodes.ForEach(n =>
                {
                    NodeView view = n as NodeView;
                    view.SortChildren();
                });

            return graphViewChange;
        }

        void CreateNodeView(Node node)
        {
            NodeView nodeView = new NodeView(node);
            nodeView.OnNodeSelected = OnNodeSelected;
            AddElement(nodeView);
        }

        public void UpdateNodeStates() => nodes.ForEach(n =>
             {
                 NodeView view = n as NodeView;
                 view.UpdateState();
             });

        private void GenerateMiniMap()
        {
            map = new MiniMap { anchored = false };
            map.SetPosition(new Rect(10, 30, 200, 200));
            Add(map);
        }
    }
}