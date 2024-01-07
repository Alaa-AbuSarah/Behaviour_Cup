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
        private Texture2D texture;

        public void Init(BehaviourTreeView behaviourTreeView)
        {
            _behaviourTreeView = behaviourTreeView;

            //Indentation hack for serch window as a transparent texture.
            texture = new Texture2D(1, 1);
            texture.SetPixel(1, 1, new Color(0, 0, 0, 0));
            texture.Apply();
        }

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
            _behaviourTreeView.CreatNodeByName(searchTreeEntry.userData.ToString(), context.screenMousePosition);

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
                          new SearchTreeEntry(new GUIContent(string.Concat(type.Name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '), texture))
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
                        new SearchTreeEntry(new GUIContent(string.Concat(type.Name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '), texture))
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
}