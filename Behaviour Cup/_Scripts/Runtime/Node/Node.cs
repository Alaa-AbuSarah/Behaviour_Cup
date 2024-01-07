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

        public virtual string Description(ref int space) => null;
        public virtual string Category => "Custom";
        public virtual void OnDrawGizmos() { }
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