using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Cup
{
    public abstract class CompositeNode : Node
    {
        [HideInInspector] public List<Node> children = new List<Node>();

        public override Node Clone()
        {
            CompositeNode node = Instantiate(this);
            node.children = children.ConvertAll(c => c.Clone());
            return node;
        }

        public override void Stop()
        {
            base.Stop();
            children.ForEach(c => c.Stop());
        }
    }
}
