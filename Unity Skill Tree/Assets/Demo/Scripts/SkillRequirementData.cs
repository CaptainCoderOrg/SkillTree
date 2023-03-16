using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skills")]
    public class SkillRequirementData : ScriptableObject, IRequirement<SkillData>
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        public bool MeetsRequirement(ISkilledEntity<SkillData> entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
