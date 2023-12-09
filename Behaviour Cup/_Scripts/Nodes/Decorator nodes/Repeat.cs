using UnityEngine;

namespace Behaviour_Cup
{
    public class Repeat : DecoratorNode
    {
        #region Data
        [Tooltip("The loops count")]
        public int count = 0;
        [Space]
        [Tooltip("Make the loop looping forever")]
        public bool infinity = true;
        [Space]
        [Tooltip("Failing when child return failure")]
        public bool returnOnFailure = true;
        #endregion

        #region Private variables
        private int current;
        #endregion

        protected override void OnStart() { current = 0; }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (child == null) return State.Failure;

            if (infinity)//Looping forever.
            {
                child.Update();
                return State.Running;
            }

            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    if (returnOnFailure) return State.Failure;//return Failure when child return failure.
                    break;
                default://Move to next loop.
                    current++;
                    break;
            }

            return current == count ? State.Success : State.Running;//Check for reach the target loops count.
        }

        public override string Category => "Loops";
    }
}