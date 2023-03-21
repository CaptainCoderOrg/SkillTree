using UnityEngine;
using CaptainCoder.Core.UnityEngine;
namespace CaptainCoder.SkillTree.UnityEngine
{
    public interface ISkill : IHasGuid
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Image { get; }
    }
}