using UnityEngine;

namespace Behaviour_Cup
{
    public class RootNode : Node
    {
        [HideInInspector] public Node child;

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate() => child.Update();

        public override Node Clone() 
        {
            RootNode node = Instantiate(this);
            node.child = child.Clone();
            return node;
        }

        public override string Description(ref int space) => "This is the start point";
    }
}