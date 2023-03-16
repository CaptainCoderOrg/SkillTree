using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public class CostRequirement : IRequirement<IPlayerCharacter, SkillData>
    {
        public CostRequirement(int cost) => Cost = cost;
        public int Cost { get; private set; }
        public bool MeetsRequirement(IPlayerCharacter entity) => entity.SkillPoints >= Cost;
    }
}
