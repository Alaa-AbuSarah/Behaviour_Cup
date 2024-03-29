using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Behaviour_Cup
{
    [CreateAssetMenu()]
    public class BehaviourTree : ScriptableObject
    {
        [HideInInspector] public Node rootNode;
        [HideInInspector] public State treeState = State.Running;
        [HideInInspector] public List<Node> nodes = new List<Node>();

        public State Update()
        {
            if (rootNode.state == State.Running)
            {
                treeState = rootNode.Update();
            }
            return treeState;
        }

#if UNITY_EDITOR

        public Node CreateNode(System.Type type)
        {
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();

            nodes.Add(node);
            Undo.RecordObject(this, "Behaviour Tree (CreateNode)");

            if (!Application.isPlaying) AssetDatabase.AddObjectToAsset(node, this);
            Undo.RegisterCreatedObjectUndo(node, "Behaviour Tree (CreateNode)");

            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            Undo.RecordObject(this, "Behaviour Tree (DeleteNode)");
            nodes.Remove(node);

            //AssetDatabase.RemoveObjectFromAsset(node);
            Undo.DestroyObjectImmediate(node);
            AssetDatabase.SaveAssets();
        }

        public void AddChild(Node parent, Node child)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (AddChild)");
                decorator.child = child;
                EditorUtility.SetDirty(decorator);
            }

            RootNode root = parent as RootNode;
            if (root)
            {
                Undo.RecordObject(root, "Behaviour Tree (AddChild)");
                root.child = child;
                EditorUtility.SetDirty(root);
            }

            CompositeNode composite = parent as CompositeNode;
            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (AddChild)");
                composite.children.Add(child);
                EditorUtility.SetDirty(composite);
            }
        }

        public void RemoveChild(Node parent, Node child)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (RemoveChild)");
                decorator.child = null;
                EditorUtility.SetDirty(decorator);
            }

            RootNode root = parent as RootNode;
            if (root)
            {
                Undo.RecordObject(root, "Behaviour Tree (RemoveChild)");
                root.child = null;
                EditorUtility.SetDirty(root);
            }

            CompositeNode composite = parent as CompositeNode;
            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (RemoveChild)");
                composite.children.Remove(child);
                EditorUtility.SetDirty(composite);
            }
        }
#endif

        public List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();

            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator && decorator.child != null)
                children.Add(decorator.child);

            RootNode root = parent as RootNode;
            if (root && root.child != null)
                children.Add(root.child);

            CompositeNode composite = parent as CompositeNode;
            if (composite)
                return composite.children;

            return children;
        }


        public void Traverse(Node node, System.Action<Node> visiter)
        {
            if (node)
            {
                visiter.Invoke(node);
                var children = GetChildren(node);
                children.ForEach(n => Traverse(n, visiter));
            }
        }

        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();
            tree.nodes = new List<Node>();
            Traverse(tree.rootNode, n =>
             {
                 tree.nodes.Add(n);
             });

            return tree;
        }

        public void Bind(Transform transform, Blackboard blackboard)
        {
            Traverse(rootNode, n =>
            {
                n.transform = transform;
                n.blackboard = blackboard;
            });
        }
    }
}