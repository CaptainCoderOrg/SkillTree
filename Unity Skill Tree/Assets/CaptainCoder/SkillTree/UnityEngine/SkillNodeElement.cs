
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.SkillTree.UnityEngine
{
    // For ease of use the Node type aliases our specific renderable type
    // using Node = ISkillNode<ISkilledEntity<IRenderableSkill>, IRenderableSkill>;
    public class SkillNodeElement : VisualElement
    {
        public SkillNodeElement(IRenderableSkill skill)
        {
            
        }
    }
}