using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
    public class SkillData : ScriptableObject, ISkill
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public Texture Image { get; private set; }
        [field: SerializeField]
        public int RequiredLevel { get; private set; } = 1;
        [field: SerializeField]
        public int RequiredSkillPoints { get; private set; } = 1;
        [field: SerializeField]
        public List<SkillRequirementData> Requirements { get; private set; }
    }
}
