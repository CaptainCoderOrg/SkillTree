using CaptainCoder.SkillTree;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine
{
    [CreateAssetMenu(fileName = "Skill Tree Test", menuName = "Skills/Skill Tree Test")]
    public class ScriptableSkillTree : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        public virtual ISkillTree<ISkilledEntity<ISkill>, ISkill> SkillTree => throw new System.NotImplementedException("SkillTree property must be overridden in subclass");
    }
}