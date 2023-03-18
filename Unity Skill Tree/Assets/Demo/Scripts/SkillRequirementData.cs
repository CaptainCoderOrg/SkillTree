using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public class SkillRequirementData : ScriptableObject, IRequirement<IPlayerCharacter, SkillData>, IRequirement<ISkilledEntity<ISkill>, ISkill>
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        public virtual bool MeetsRequirement(IPlayerCharacter entity)
        {
            // ISkilledEntity<ISkill> test = entity;
            throw new System.NotImplementedException();
        }

        bool IRequirement<ISkilledEntity<ISkill>, ISkill>.MeetsRequirement(ISkilledEntity<ISkill> entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
