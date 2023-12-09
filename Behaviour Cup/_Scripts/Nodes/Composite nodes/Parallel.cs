using UnityEngine;

namespace Behaviour_Cup
{
    public class Parallel : CompositeNode
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
                    case State.Failure:
                        children.ForEach(c => c.Stop());
                        return State.Failure;
                }
            }

            return (allChildrenFinished) ? State.Success : State.Running;
        }

        public override string Category => "Paralleling";

        public override string Description(ref int space)
        {
            space = 25;
            return "Run all children in same time\nReturn success when all children success";
        }
    }
}