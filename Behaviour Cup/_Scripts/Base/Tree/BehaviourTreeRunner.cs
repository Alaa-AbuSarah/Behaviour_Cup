using UnityEngine;

namespace Behaviour_Cup
{
    [RequireComponent(typeof(Blackboard))]
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;

        private void Awake()
        {
            tree = tree.Clone();
            tree.Bind(transform,GetComponent<Blackboard>());
        }

        private void Update() => tree.Update();
    }
}