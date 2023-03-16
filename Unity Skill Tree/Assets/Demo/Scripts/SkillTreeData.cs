using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill Tree", menuName = "Skills/Skill Tree")]
    public class SkillTreeData : UnityEngine.SkillTreeData<IPlayerCharacter, SkillData>
    {
        public override void AddSkillToBuilder(SkillTreeBuilder<IPlayerCharacter, SkillData> builder, SkillData skill)
        {
            builder.AddRequirement(skill, new LevelRequirement(skill.RequiredLevel));
            builder.AddRequirement(skill, new CostRequirement(skill.RequiredSkillPoints));
            foreach (IRequirement<IPlayerCharacter, SkillData> requirement in skill.Requirements)
            {
                builder.AddRequirement(skill, requirement);
            }
        }
    }
}
