using CaptainCoder.Core.UnityEngine;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class ScriptableSkillTree : ScriptableObject, IHasGuid
    {
        [field: SerializeField]
        public string GUID { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        public virtual ISkillTree<ISkilledEntity<ISkill>, ISkill> SkillTree => throw new System.NotImplementedException("SkillTree property must be overridden in subclass");
        string IHasGuid.Guid { get => GUID; set => GUID = value; }
    }
}