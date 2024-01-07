using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Behaviour_Cup
{
    [CustomEditor(typeof(BehaviourTreeRunner))]
    public class BehaviourTreeRunnerEditor : Editor
    {
        BehaviourTreeRunner runner;

        private void OnEnable() => runner = target as BehaviourTreeRunner;

        private void OnSceneGUI()
        {
            BehaviourTree tree = runner.tree;
            if (tree) tree.Bind(runner.transform, runner.GetComponent<Blackboard>());
        }
    }
}