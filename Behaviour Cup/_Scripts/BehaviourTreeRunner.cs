using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Cup
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;

        private void Start()
        {
            tree = tree.Clone();
            tree.Bind(transform);
        }

        private void Update() => tree.Update();
    }
}