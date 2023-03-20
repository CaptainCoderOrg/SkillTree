using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter
    {
        [field: SerializeField]
        public int Level { get; private set; }
        [field: SerializeField]
        public int SkillPoints  { get; private set; }
        [field: SerializeField]
        public Alignment Alignment { get; private set; }
        [field: SerializeField]
        public List<SkillData> AcquiredSkills { get; private set; }
        public HashSet<SkillData> Skills => AcquiredSkills.ToHashSet();
        HashSet<SkillData> ISkilledEntity<SkillData>.Skills => Skills;
    }
}