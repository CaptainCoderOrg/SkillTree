using System.Xml;
using UnityEngine;
using UnityEditor;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillNodeGenerator : IUXMLGenerator<ISkillNode<ISkilledEntity<ISkill>, ISkill>>
    {
        public static readonly string s_SkillNodeElement = "CaptainCoder.SkillTree.UnityEngine.SkillNodeElement";
        private readonly XmlElement _edgeContainer;
        public SkillNodeGenerator(XmlElement edgeContainer) => _edgeContainer = edgeContainer;

        public XmlElement ToXMLElement(ISkillNode<ISkilledEntity<ISkill>, ISkill> toConvert)
        {         
            XmlElement skillNode = UXML.XML.CreateElement(s_SkillNodeElement);
            skillNode.SetAttribute("name", UXML.SanitizeSkillName(toConvert.Skill));
            skillNode.SetAttribute("style", $"{UXML.TransparentBackground} {UXML.AbsolutePosition} {ImageStyle(toConvert.Skill.Image)}");
            skillNode.SetAttribute("display-name", toConvert.Skill.Name);
            skillNode.SetAttribute("display-description", toConvert.Skill.Description);
            foreach (var child in toConvert.Children)
            {
                XmlElement lineNode = UXML.CreateLineElement(toConvert.Skill, child.Skill);
                _edgeContainer.AppendChild(lineNode);
            }     
            return skillNode;
        }

        private string ImageStyle(Sprite sprite) 
        {
            string width = $"width: {sprite.texture.width}px;";
            string height = $"height: {sprite.texture.height}px;";
            string path = AssetDatabase.GetAssetPath(sprite);
            AssetDatabase.TryGetGUIDAndLocalFileIdentifier(sprite, out string guid, out long localId);
            string image = $"background-image: url('project://database/{path}?fileID={localId}&guid={guid}&type=3#{sprite.name}');";
            return $"{width} {height} {image}";
        }
    }
}