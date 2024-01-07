using UnityEngine;

namespace Behaviour_Cup
{
    public abstract class DecoratorNode : Node
    {
        [HideInInspector] public Node child;

        public override Node Clone()
        {
            DecoratorNode node = Instantiate(this);
            node.child = child.Clone();
            return node;
        }

        public override void Stop()
        {
            base.Stop();
            child.Stop();
        }
    }
}