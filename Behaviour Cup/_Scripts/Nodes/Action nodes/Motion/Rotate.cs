using UnityEngine;

namespace Behaviour_Cup
{
    public class Rotate : ActionNode
    {
        public string targetKey = "Target";
        public float speed = 5f;
        [Space(10)]
        [Tooltip("For rotate full object or specific object")] public bool self = true;
        public string rotatorObjectKey = "Rotator";

        private Transform target;
        private Transform rotator;

        protected override void OnStart()
        {
            target = blackboard.Get_Component<Transform>(targetKey);
            rotator = (self) ? transform : blackboard.Get_Component<Transform>(rotatorObjectKey);
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (target == null)
            {
                Debug.LogError("No Target in blackboard");
                return State.Failure;
            }
            else if (rotator == null)
            {
                Debug.LogError("No Rotator in blackboard");
                return State.Failure;
            }

            Quaternion lookRotation = Quaternion.LookRotation((target.position - rotator.position).normalized);
            rotator.rotation = Quaternion.Slerp(rotator.rotation, lookRotation, speed * Time.deltaTime);

            return State.Success;
        }

        public override string Category => "Motion";
    }
}