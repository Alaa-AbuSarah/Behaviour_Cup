namespace Behaviour_Cup
{
    public class ParallelComplete : CompositeNode
    {
        protected override void OnStart()
        {
            if (children.Count == 0) return;

            foreach (var child in children)
                child.Update();
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (children.Count == 0) return State.Failure;

            bool allChildrenFinished = true;

            children.ForEach(c =>
            {
                if (c.state == State.Running)
                {
                    allChildrenFinished = false;
                    c.Update();
                }
            });

            return (allChildrenFinished) ? State.Success : State.Running;
        }

        public override string Category => "Paralleling";

        public override string Description(ref int space)
        {
            space = 25;
            return "Run all children in same time\nReturn success When all children finished";
        }
    }
}