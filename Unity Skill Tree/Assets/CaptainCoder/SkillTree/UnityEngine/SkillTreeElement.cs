using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Linq;

namespace CaptainCoder.SkillTree.UnityEngine
{
    // For ease of use the Node type aliases our specific renderable type
    using Node = ISkillNode<ISkilledEntity<ISkill>, ISkill>;
    // using SkillTreeData = SkillTreeData<ISkilledEntity<ISkill>, ISkill>;

    public class SkillTreeElement : VisualElement
    {
        private ISkillTree<ISkilledEntity<ISkill>, ISkill> _skills;
        public SkillTreeElement()
        {
            generateVisualContent += OnGenerateVisualContent;
        }
        private void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            VisualElement anchors = parent?.Q<VisualElement>("Anchors");
            if (anchors == null) { return; }
            var nodes = GetImagesContainer().Children().Where(c => c is SkillNodeElement).Select(c => c as SkillNodeElement);
            foreach (SkillNodeElement node in nodes)
            {
                VisualElement anchor = anchors.Q<VisualElement>(node.Skill.Name.Replace(" ",""));
                if (anchor != null)
                {
                    anchor.style.width = node.layout.width;
                    anchor.style.height = node.layout.height;
                    node.style.left = anchor.layout.x;
                    node.style.top = anchor.layout.y;
                }
            }

        }


        public void Generate(ISkillTree<ISkilledEntity<ISkill>, ISkill> skillTree)
        {
            VisualElement images = GetImagesContainer();
            images.Clear();
            foreach (Node node in skillTree.Nodes)
            {
                SkillNodeElement nodeElement = new(node.Skill);
                images.Add(nodeElement);
            }
            _skills = skillTree;
        }

        private VisualElement GetImagesContainer()
        {
            VisualElement images = this.Q<VisualElement>("NodeImages");
            if (images == null)
            {
                images = new VisualElement { name = "NodeImages" };
                images.style.position = Position.Absolute;
                images.style.width = new StyleLength(new Length(100, LengthUnit.Percent));
                images.style.height = new StyleLength(new Length(100, LengthUnit.Percent));
                Add(images);
            }
            return images;
        }

        public void Init(string skillTreeAsset)
        {
            SkillTreeAsset = skillTreeAsset;

            ScriptableSkillTree data = AssetDatabase.LoadAssetAtPath<ScriptableSkillTree>(skillTreeAsset);
            if (data == null) { return; }

            Generate(data.SkillTree);
        }

        public string SkillTreeAsset { get; set; }

        public sealed new class UxmlFactory : UxmlFactory<SkillTreeElement, UxmlTraits> { }

        public sealed new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription _skillTreeAsset = new() { name = "skill-tree-asset", defaultValue = string.Empty };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var line = ve as SkillTreeElement;
                string AsString(UxmlStringAttributeDescription e) => e.GetValueFromBag(bag, cc);
                line.Init(AsString(_skillTreeAsset));
            }
        }
    }
}