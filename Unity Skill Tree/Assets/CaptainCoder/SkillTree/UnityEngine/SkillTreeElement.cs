using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace CaptainCoder.SkillTree.UnityEngine
{
    // For ease of use the Node type aliases our specific renderable type
    using Node = ISkillNode<ISkilledEntity<IRenderableSkill>, IRenderableSkill>;
    using SkillTreeData = SkillTreeData<ISkilledEntity<IRenderableSkill>, IRenderableSkill>;

    public class SkillTreeElement : VisualElement
    {

        public SkillTreeElement()
        {

        }

        public void Generate(ISkillTree<ISkilledEntity<IRenderableSkill>, IRenderableSkill> skillTree)
        {
            foreach (Node node in skillTree.Nodes)
            {
                SkillNodeElement nodeElement = new (node.Skill);
                Add(nodeElement);
            }        
        }

        public void Init(string skillTreeAsset)
        {
            SkillTreeAsset = skillTreeAsset;
            ScriptableObject data = AssetDatabase.LoadAssetAtPath<ScriptableObject>("Assets/Demo/Skill Tree/Paladin Skill Tree.asset");
            SkillTreeData<ISkilledEntity<IRenderableSkill>, IRenderableSkill> skillTree = data as SkillTreeData;
            Debug.Log(data);
            Debug.Log(skillTree);
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