using System.Collections.Generic;
using UnityEngine;
namespace CaptainCoder.SkillTree.UnityEngine
{
    public interface ISkill
    {
        public string GUID { get; }
        public string Name { get; }
        public string Description { get; }
        public Sprite Image { get; }
    }
}