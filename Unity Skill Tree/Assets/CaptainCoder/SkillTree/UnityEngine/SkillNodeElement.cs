using UnityEngine.UIElements;
using UnityEditor;

namespace CaptainCoder.SkillTree.UnityEngine
{
    // For ease of use the Node type aliases our specific renderable type
    // using Node = ISkillNode<ISkilledEntity<IRenderableSkill>, IRenderableSkill>;
    public class SkillNodeElement : VisualElement
    {
        public SkillNodeElement()
        {

        }

        public SkillNodeElement(ISkill skill) => Init(skill);

        public void Init(ISkill skill)
        {
            name = $"Skill: {skill.Name}";
            Image img = new ();
            img.image = skill.Image.texture;
            Add(img);
            style.position = Position.Absolute;
            Skill = skill;
        }

        private void Init(string skillAssetPath)
        {
            SkillAssetPath = skillAssetPath;
        }

        public ISkill Skill { get; private set; }

        public string SkillAssetPath { get; set; }

        public sealed new class UxmlFactory : UxmlFactory<SkillNodeElement, UxmlTraits> { }

        public sealed new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription _skillAssetPath = new() { name = "skill-asset-path", defaultValue = string.Empty };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var line = ve as SkillNodeElement;
                string AsString(UxmlStringAttributeDescription e) => e.GetValueFromBag(bag, cc);
                line.Init(AsString(_skillAssetPath));
            }
        }
    }
}