using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public interface IPlayerCharacter : ISkilledEntity<SkillData>
    {
        public int Level { get; }
        public int SkillPoints { get; }
        public Alignment Alignment { get; }
    }
}
