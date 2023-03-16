using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skills")]
    public class SkillRequirementData : ScriptableObject, IRequirement<IPlayerCharacter, SkillData>
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        public virtual bool MeetsRequirement(IPlayerCharacter entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
