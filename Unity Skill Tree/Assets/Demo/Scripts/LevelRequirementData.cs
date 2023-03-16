using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine
{
    [CreateAssetMenu(fileName = "Level Requirement", menuName = "Skills/Level Requirement")]
    public class LevelRequirement : SkillRequirementData
    {
        [field: SerializeField]
        public int RequiredLevel { get; private set; }

        public bool MeetsRequirement(ISkilledEntity<SkillData> entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
