using UnityEngine;

namespace Behaviour_Cup
{
    public class Wait : ActionNode
    {
        public float duration = 1f;

        float startTime;

        protected override void OnStart() => startTime = Time.time;

        protected override void OnStop() { }

        protected override State OnUpdate() => (Time.time > duration + startTime) ? State.Success : State.Running;

        public override string Category => "Delay";
    }
}