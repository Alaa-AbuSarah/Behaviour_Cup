namespace Behaviour_Cup
{
    public class Failure : ActionNode
    {
        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate() => State.Failure;

        public override string Category => "Returning";

        public override string Description(ref int space) => "Return failure every time";
    }
}