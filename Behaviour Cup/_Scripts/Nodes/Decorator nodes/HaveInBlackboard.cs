namespace Behaviour_Cup
{
    public class HaveInBlackboard : DecoratorNode
    {
        public string key = "Key";

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            bool have = blackboard.Have(key);

            return (have) ? child.Update() : State.Failure;
        }

        public override string Category => "Blackboard";
    }
}