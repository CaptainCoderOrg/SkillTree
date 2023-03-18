using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill Tree", menuName = "Skills/Skill Tree")]
    public class GameSkillTreeData : SkillTreeData<IPlayerCharacter, SkillData>
    {
    }
}
