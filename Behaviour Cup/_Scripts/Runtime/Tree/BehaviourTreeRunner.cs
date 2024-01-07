using UnityEngine;

namespace Behaviour_Cup
{
    [RequireComponent(typeof(Blackboard))]
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;

        private void Awake()
        {
            if (!tree)
            {
                Debug.LogError($"No Tree in {name}");
                return;
            }

            tree = tree.Clone();
            tree.Bind(transform, GetComponent<Blackboard>());
        }

        private void Update()
        {
            if (tree) tree.Update();
        }

        private void OnDrawGizmos()
        {
            if (tree) tree.nodes.ForEach(n => n.OnDrawGizmos());
        }

        private void OnDrawGizmosSelected()
        {
            if (tree) tree.nodes.ForEach(n => n.OnDrawGizmosSelected());
        }
    }
}