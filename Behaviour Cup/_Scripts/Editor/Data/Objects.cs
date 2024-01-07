using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace Behaviour_Cup
{
    public class DataEntitiyListData
    {
        public Type type;
        public string listName = "";
        public string label = "";
        public bool keyLabel = false;
        public bool valueLabel = false;
        public Layout layout = Layout.Horizontal;
        public float spaces = 1f;

        public DataEntitiyListData(Type type, string listName, string label = "", bool keyLabel = false, bool valueLabel = false, Layout layout = Layout.Horizontal, float spaces = 1f)
        {
            this.type = type;
            this.listName = listName;
            this.label = label;
            this.keyLabel = keyLabel;
            this.valueLabel = valueLabel;
            this.layout = layout;
            this.spaces = spaces;
        }
    }

    public class Category
    {
        public string name = "";
        public List<SearchTreeEntry> entries = new List<SearchTreeEntry>();

        public Category(string name)
        {
            this.name = name;
        }
    }
}