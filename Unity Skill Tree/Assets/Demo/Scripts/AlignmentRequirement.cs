using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "AlignmentRequirement", menuName = "Skills/Requirement/Alignment")]
    public class AlignmentRequirement : SkillRequirementData
    {
        [field: SerializeField]
        public List<Alignment> Alignments { get; private set; }
        public override bool MeetsRequirement(IPlayerCharacter entity) => Alignments.Contains(entity.Alignment);
    }
}
