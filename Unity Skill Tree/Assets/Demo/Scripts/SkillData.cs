using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skills")]
    public class SkillData : ScriptableObject, ISkill
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        [field: SerializeField]
        public Texture Image { get; private set; }

        [field: SerializeField]
        public List<SkillRequirementData> requirements { get; private set; }
    }
}
