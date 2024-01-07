using UnityEngine;

namespace Behaviour_Cup
{
    public class DebugLogWarning : ActionNode
    {
        public string message;

        protected override void OnStart() => Debug.LogWarning(message);

        protected override void OnStop() { }

        protected override State OnUpdate() => State.Success;

        public override string Category => "Debug";
    }
}

