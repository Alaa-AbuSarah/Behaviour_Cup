using UnityEngine;

namespace Behaviour_Cup
{
    public class Timer : DecoratorNode
    {
        public float time = 1f;

        private float timer;
        private bool active = false;

        protected override void OnStart()
        {
            if (!active)
            {
                timer = Time.time + time;
                active = true;
            }
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (Time.time >= timer)
            {
                active = false;
                return child.Update();
            }

            return State.Failure;
        }

        public override string Category => "Timing";
        public override string Description(ref int space)
        {
            space = 15;
            return $"The timer run the child\nevery period of time";
        }
    }
}