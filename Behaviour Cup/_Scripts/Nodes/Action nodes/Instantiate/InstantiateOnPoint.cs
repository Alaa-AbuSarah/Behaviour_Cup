using UnityEngine;

namespace Behaviour_Cup
{
    public class InstantiateOnPoint : ActionNode
    {
        [Header("Instantiate Point")]
        public string gameObjectKey = "Instantiator Target";
        public Vector3 offset = Vector3.zero;
        [Space(10)]
        public bool useParent = false;
        public string parentKey = "Parent";

        private GameObject target;

        protected override void OnStart() => target = blackboard.Get_GameObject(gameObjectKey);

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (target != null)
            {
                if (!useParent)
                {
                    Instantiate(target, transform.TransformPoint(offset), Quaternion.Euler(Vector3.zero));
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
                        Instantiate(target, transform.TransformPoint(offset), Quaternion.Euler(Vector3.zero), parent);
                        return State.Success;
                    }
                }
            }

            Debug.LogError("No target gameObject in blackboard");
            return State.Failure;
        }

        public override void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(transform.TransformPoint(offset), 0.25f);
        }

        public override string Category => "Instantiate";
    }
}