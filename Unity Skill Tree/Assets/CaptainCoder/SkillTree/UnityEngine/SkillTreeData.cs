using System.Collections.Generic;
using UnityEngine;
namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillTreeData<E, S> : ScriptableObject where E : ISkilledEntity<S> where S : ISkill
    {
        [field: SerializeField]
        public S Root { get; private set; }
        [field: SerializeField]
        public List<Edge> Edges { get; private set; }

        public ISkillTree<E, S> BuildTree()
        {
            SkillTreeBuilder<E, S> builder = new(Root);
            AddSkillToBuilder(builder, Root);
            foreach (Edge e in Edges)
            {
                builder.AddSkill(e.Parent, e.Child);
                AddSkillToBuilder(builder, e.Child);
            }
            return builder.Build();
        }

        public  virtual void AddSkillToBuilder(SkillTreeBuilder<E, S> builder, S skill)
        {
            throw new System.NotImplementedException("Add SkillToBuilder must be implemented.");
        }

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