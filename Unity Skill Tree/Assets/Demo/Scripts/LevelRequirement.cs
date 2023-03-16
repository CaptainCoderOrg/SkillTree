using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public class LevelRequirement : IRequirement<IPlayerCharacter, SkillData>
    {
        public LevelRequirement(int minimumLevel) => MinimumLevel = minimumLevel;
        public int MinimumLevel { get; private set; }
        public bool MeetsRequirement(IPlayerCharacter entity) => entity.Level >= MinimumLevel;
    }
}
