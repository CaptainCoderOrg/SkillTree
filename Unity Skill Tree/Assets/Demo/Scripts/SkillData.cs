using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
    public class SkillData : ScriptableObject, ISkill, IHasRequirements<IPlayerCharacter, SkillData>
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public Sprite Image { get; private set; }
        [field: SerializeField]
        public int RequiredLevel { get; private set; } = 1;
        [field: SerializeField]
        public int RequiredSkillPoints { get; private set; } = 1;
        [field: SerializeField]
        public List<SkillRequirementData> Requirements { get; private set; }

        // IEnumerable<IRequirement<ISkilledEntity<ISkill>, ISkill>> ISkill.Requirements => Requirements.AsEnumerable();
    }
}
