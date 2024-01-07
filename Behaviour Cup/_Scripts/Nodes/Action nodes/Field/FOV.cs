using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Behaviour_Cup
{
    public class FOV : ActionNode
    {
        [Header("Settings")]
        public float radius = 5f;
        [Range(0.1f, 360)] public float angle = 100f;
        public Vector3 offset = Vector3.up;
        [Space]
        public LayerMask targetMask;
        public LayerMask obstructionMask;
        [Space(10)]
        [Header("Tag")]
        public bool useTag = false;
        public string tag = "";
        [Space(10)]
        [Header("Outputs")]
        [Tooltip("The finded transform saving key")] public string savingKey = "Target";

        private List<Transform> targets = new List<Transform>();

        private void OnValidate()
        {
            if (radius <= 0.01f) radius = 0.01f;
        }

        protected override void OnStart()
        {
            targets = (useTag) ? Field(tag) : Field();
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (targets.Count > 0)
            {
                blackboard.Set_Component(savingKey, targets[0]);
                return State.Success;
            }

            blackboard.Set_Component(savingKey, null);
            return State.Failure;
        }

        /// <summary>
        /// Check for transforms in range.
        /// </summary>
        /// <param name="tag">Condition tag in object</param>
        /// <returns>List of wanted type in rage</returns>
        public List<Transform> Field(string tag = null)
        {
            List<Transform> value = new List<Transform>();

            //Find all objects in range.
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position + offset, radius, targetMask);

            for (int i = 0; i < rangeChecks.Length; i++)
            {
                Transform target = rangeChecks[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (tag != null && target.tag != tag) continue;//Check for condition tag.

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    //Object in view angle.

                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        //No obstruction in direction.

                        Transform t;
                        t = target.transform;

                        if (t != null)
                        {
                            //Object have a Wanted type.

                            value.Add(t);//Add the Wanted type to the lest.
                            Debug.DrawLine(transform.position, target.position, Color.green);
                        }
                    }
                }
            }

            return value;//Send back the result.
        }

        public override void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Vector3 centerPoint = transform.position + offset;

            Handles.color = Color.white;
            Handles.DrawWireArc(centerPoint, Vector3.up, Vector3.forward, 360, radius);

            Vector3 viewAngle01 = DirectionFromAngle(transform.eulerAngles.y, -angle / 2);
            Vector3 viewAngle02 = DirectionFromAngle(transform.eulerAngles.y, angle / 2);

            Handles.color = Color.yellow;
            Handles.DrawLine(centerPoint, centerPoint + viewAngle01 * radius);
            Handles.DrawLine(centerPoint, centerPoint + viewAngle02 * radius);
#endif
        }

        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        public override string Category => "Field";
    }
}