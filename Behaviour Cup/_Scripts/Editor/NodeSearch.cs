using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using System.Linq;
using System;

namespace Behaviour_Cup
{
    public class NodeSearch : ScriptableObject, ISearchWindowProvider
    {
        private BehaviourTreeView _behaviourTreeView;

        public void Init(BehaviourTreeView behaviourTreeView) => _behaviourTreeView = behaviourTreeView;

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            var tree = new List<SearchTreeEntry>
            {
                new SearchTreeGroupEntry(new GUIContent("Create Node"),0),
            };

            AddCategory<ActionNode>(tree, "Action Node");
            AddCategory<CompositeNode>(tree, "Composite Node");
            AddCategory<DecoratorNode>(tree, "Decorator Node");

            return tree;
        }

        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            _behaviourTreeView.CreatNodeByName(searchTreeEntry.userData.ToString());

            return true;
        }

        public void AddCategory<T>(List<SearchTreeEntry> tree, string name) where T : Node
        {
            tree.Add(new SearchTreeGroupEntry(new GUIContent(name), 1));

            var types = TypeCache.GetTypesDerivedFrom<T>();
            List<Category> subCategories = new List<Category>();

            List<SearchTreeEntry> noSubCategories = new List<SearchTreeEntry>();

            foreach (var type in types)
            {
                T t = CreateInstance(type) as T;
                if (t.Category == null)
                {
                    noSubCategories.Add
                      (
                          new SearchTreeEntry(new GUIContent(string.Concat(type.Name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ')))
                          {
                              userData = type.Name,
                              level = 2
                          }
                      );

                    continue;
                }

                Category category = subCategories.Find(c => t.Category == c.name);

                if (category == null)
                {
                    category = new Category(t.Category);
                    subCategories.Add(category);
                }

                category.entries.Add
                    (
                        new SearchTreeEntry(new GUIContent(string.Concat(type.Name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ')))
                        {
                            userData = type.Name,
                            level = 3
                        }
                    );
            }

            foreach (var c in subCategories)
            {
                tree.Add(new SearchTreeGroupEntry(new GUIContent(c.name), 2));
                tree.AddRange(c.entries);
            }

            if (subCategories.Count > 0)
                noSubCategories.Insert(0, new SearchTreeEntry(new GUIContent("------------------------------------------------")) { userData = "", level = 2 });

            if (noSubCategories.Count > 0)
                tree.AddRange(noSubCategories);
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