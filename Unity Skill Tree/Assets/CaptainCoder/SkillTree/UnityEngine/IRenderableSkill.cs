using UnityEngine;
namespace CaptainCoder.SkillTree.UnityEngine
{

    public interface IRenderableSkill : ISkill
    {
        public Texture Image { get;}
    }
}