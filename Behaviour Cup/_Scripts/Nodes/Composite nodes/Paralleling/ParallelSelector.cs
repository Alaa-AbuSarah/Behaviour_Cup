namespace Behaviour_Cup
{
    public class ParallelSelector : CompositeNode
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

            foreach (var child in children)
            {
                switch (child.state)
                {
                    case State.Running:
                        allChildrenFinished = false;
                        child.Update();
                        break;
                    case State.Success:
                        children.ForEach(c =>
                        {
                            if (c != child) c.Stop();
                        });
                        return State.Success;
                }
            }

            if (allChildrenFinished)
            {
                bool allChildrenFailure = true;
                children.ForEach(c =>
                {
                    if (c.state != State.Failure) allChildrenFailure = false;
                });

                return (allChildrenFailure) ? State.Failure : State.Success;
            }
            else return State.Running;
        }

        public override string Category => "Paralleling";

        public override string Description(ref int space)
        {
            space = 25;
            return "Run all children in same time\nReturn success if one child success";
        }
    }
}