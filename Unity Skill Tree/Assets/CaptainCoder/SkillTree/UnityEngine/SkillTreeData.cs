#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillTreeData<E, S> : ScriptableSkillTree where E : ISkilledEntity<S> where S : ISkill, IHasRequirements<E, S>
    {
        [field: SerializeField]
        public S Root { get; private set; }
        [field: SerializeField]
        public List<Edge> Edges { get; private set; }
        public bool GenerateUXML;
        public override ISkillTree<ISkilledEntity<ISkill>, ISkill> SkillTree
        {
            get
            {
                SkillTreeBuilder<ISkilledEntity<ISkill>, ISkill> builder = new(Root);
                foreach (Edge edge in Edges)
                {
                    builder.AddSkill(edge.Parent, edge.Child);
                }
                return builder.Build();
            }
        }

        public ISkillTree<E, S> BuildSkillTree()
        {
            HashSet<S> nodes = new() { Root };
            SkillTreeBuilder<E, S> builder = new(Root);

            foreach (Edge edge in Edges)
            {
                builder.AddSkill(edge.Parent, edge.Child);
                nodes.Add(edge.Parent);
                nodes.Add(edge.Child);
            }

            foreach (S node in nodes)
            {
                foreach (IRequirement<E, S> requirement in node.Requirements)
                {
                    builder.AddRequirement(node, requirement);
                }
            }
            return builder.Build();
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            if (!GenerateUXML) { return; }

            string treeDataPath = AssetDatabase.GetAssetPath(this);
            List<string> components = treeDataPath.Split("/").ToList();
            components.RemoveAt(components.Count - 1);
            string path = $"{string.Join("/", components)}/{Name}.uxml";

            SkillTreeDeserializer deserializer = SkillTreeDeserializer.Default;

            ISkillTreeMetaData metaData =
                File.Exists(path) ?
                deserializer.ParseMetaData(path) :
                ISkillTreeMetaData.Default;

            SkillTreeGenerator generator = new(metaData);
            string uxml = generator.ToUXMLDocString(this);
            File.WriteAllText(path, uxml);
            AssetDatabase.Refresh();

            GenerateUXML = false;
        }
#endif

        [System.Serializable]
        public class Edge
        {
            [field: SerializeField]
            public S Parent { get; private set; }
            [field: SerializeField]
            public S Child { get; private set; }
        }
    }
}