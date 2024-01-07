namespace Behaviour_Cup
{
    public class Sequencer : CompositeNode
    {
        private int current;

        protected override void OnStart() => current = 0;

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (children.Count == 0) return State.Failure;

            var child = children[current];
            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                case State.Success:
                    current++;
                    break;
            }

            return current == children.Count ? State.Success : State.Running;
        }

        public override string Category => "Sequencing";

        public override string Description(ref int space)
        {
            space = 25;
            return "Running all children one by one\nReturn success when all children success";
        }
    }
}