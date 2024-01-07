using UnityEngine;

namespace Behaviour_Cup
{
    public class InstantiateOnTransform : ActionNode
    {
        [Header("Instantiate Point")]
        public string gameObjectKey = "Instantiator Target";
        public string transformkey = "Instantiating Transform";
        [Space(10)]
        public bool useParent = false;
        public string parentKey = "Parent";

        private GameObject target;
        private Transform point;

        protected override void OnStart()
        {
            target = blackboard.Get_GameObject(gameObjectKey);
            point = blackboard.Get_Component<Transform>(transformkey);
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (point == null)
            {
                Debug.LogError("No Instantiating Transform in blackboard");
                return State.Failure;
            }

            if (target != null)
            {
                if (!useParent)
                {
                    Instantiate(target, point.position, Quaternion.Euler(Vector3.zero));
                    return State.Success;
                }
                else
                {
                    Transform parent = blackboard.Get_Component<Transform>(parentKey);
                    if (parent == null)
                    {
                        Debug.LogError("No parent transform in blackboard");
                        return State.Failure;
                    }
                    else
                    {
                        Instantiate(target, point.position, Quaternion.Euler(Vector3.zero), parent);
                        return State.Success;
                    }
                }
            }

            Debug.LogError("No target gameObject in blackboard");
            return State.Failure;
        }

        public override void OnDrawGizmos()
        {
            Transform t = blackboard.Get_Component<Transform>(transformkey);

            Gizmos.color = Color.gray;
            if (t != null) Gizmos.DrawSphere(t.position, 0.25f);
        }

        public override string Category => "Instantiate";
    }
}