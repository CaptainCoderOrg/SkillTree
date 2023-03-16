using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill Tree", menuName = "Skills/Skill Tree")]
    public class SkillTreeData : ScriptableObject
    {
        [field: SerializeField]
        public SkillData Root { get; private set; }
        [field: SerializeField]
        public List<Edge> Edges { get; private set; }

        public ISkillTree<IPlayerCharacter, SkillData> BuildTree()
        {
            SkillTreeBuilder<IPlayerCharacter, SkillData> builder = new(Root);
            AddSkillToBuilder(builder, Root);
            foreach (Edge e in Edges)
            {
                builder.AddSkill(e.Parent, e.Child);
                AddSkillToBuilder(builder, e.Child);
            }
            return builder.Build();
        }

        private static void AddSkillToBuilder(SkillTreeBuilder<IPlayerCharacter, SkillData> builder, SkillData skill)
        {
            builder.AddRequirement(skill, new LevelRequirement(skill.RequiredLevel));
            builder.AddRequirement(skill, new CostRequirement(skill.RequiredSkillPoints));
            foreach (IRequirement<IPlayerCharacter, SkillData> requirement in skill.Requirements)
            {
                builder.AddRequirement(skill, requirement);
            }
        }
    }

    [System.Serializable]
    public class Edge
    {
        [field: SerializeField]
        public SkillData Parent { get; private set; }
        [field: SerializeField]
        public SkillData Child { get; private set; }
    }
}
