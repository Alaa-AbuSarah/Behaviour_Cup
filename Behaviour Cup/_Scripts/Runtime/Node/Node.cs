using UnityEngine;

namespace Behaviour_Cup
{
    public abstract class Node : ScriptableObject
    {
        [HideInInspector] public State state = State.Running;
        [HideInInspector] public bool started = false;
        [HideInInspector] public string guid;

        [HideInInspector] public Vector2 position;

        [HideInInspector] public Blackboard blackboard;
        [HideInInspector] public Transform transform;

        /// <summary>
        /// Drawing text on Inspictor
        /// </summary>
        /// <param name="space">The total spacing for drawing</param>.
        /// <returns>Text for drawing</returns>
        public virtual string Description(ref int space) => null;
        /// <summary>
        /// The Category in Search window.
        /// </summary>
        public virtual string Category => "Custom";
        /// <summary>
        /// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
        /// </summary>
        public virtual void OnDrawGizmos() { }
        /// <summary>
        /// Implement OnDrawGizmosSelected to draw a gizmo if the object is selected.
        /// </summary>
        public virtual void OnDrawGizmosSelected() { }

        public State Update()
        {
            if (!started)
            {
                OnStart();
                started = true;
            }

            state = OnUpdate();

            if (state == State.Failure || state == State.Success)
            {
                OnStop();
                started = false;
            }

            return state;
        }

        public virtual void Stop()
        {
            state = State.Failure;
            OnStop();
            started = false;
        }

        public virtual Node Clone() => Instantiate(this);

        /// <summary>
        /// Get call when first start run the node.
        /// </summary>
        protected abstract void OnStart();
        /// <summary>
        /// Get call when exit the node.
        /// </summary>
        protected abstract void OnStop();
        /// <summary>
        /// Get call every frame when node is running.
        /// </summary>
        /// <returns>The current state of the node</returns>
        protected abstract State OnUpdate();
    }
}