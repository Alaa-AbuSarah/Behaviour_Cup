using UnityEngine;

namespace Behaviour_Cup
{
    public class DebugLog : ActionNode
    {
        public string message;

        protected override void OnStart() => Debug.Log(message);

        protected override void OnStop() { }

        protected override State OnUpdate() => State.Success;

        public override string Category => "Debug";
    }
}