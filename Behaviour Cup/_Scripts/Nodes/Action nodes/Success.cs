namespace Behaviour_Cup
{
    public class Success : ActionNode
    {
        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate() => State.Success;

        public override string Category => "Returning";

        public override string Description(ref int space) => "Return success every time";
    }
}