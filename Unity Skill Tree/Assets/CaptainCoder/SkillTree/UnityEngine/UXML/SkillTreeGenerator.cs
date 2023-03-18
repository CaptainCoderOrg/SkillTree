using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEditor;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillTreeGenerator : IUXMLGenerator<ScriptableSkillTree>
    {
        public static readonly string UI = "UnityEngine.UIElements";
        public static readonly string VisualElement = "ui:VisualElement";
        public static readonly string Background = "background-color: rgba(0, 0, 0, 0);";
        public static readonly string Position = "position: absolute;";
        
        private string ImageStyle(Sprite sprite) 
        {
            string width = $"width: {sprite.texture.width}px;";
            string height = $"height: {sprite.texture.height}px;";
            string path = AssetDatabase.GetAssetPath(sprite);
            AssetDatabase.TryGetGUIDAndLocalFileIdentifier(sprite, out string guid, out long localId);
            string image = $"background-image: url('project://database/{path}?fileID={localId}&guid={guid}&type=3#{sprite.name}');";
            return $"{width} {height} {image}";
        }
        public string ToUXMLElement(ScriptableSkillTree toConvert)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ui", UI);

            XmlDocument xml = new ();
            XmlElement el = xml.CreateElement("ui:UXML", UI);
            XmlElement container = xml.CreateElement(VisualElement, UI);
            container.SetAttribute("style", $"{Background} width:100%; height:100%; {Position}");
            container.SetAttribute("name", "Nodes");
            XmlElement edges = xml.CreateElement(VisualElement, UI);
            edges.SetAttribute("style", $"{Background} width:100%; height:100%; {Position}");
            edges.SetAttribute("name", "Edges");
            el.AppendChild(edges);
            el.AppendChild(container);
            
            
            foreach(var node in toConvert.SkillTree.Nodes)
            {
                XmlElement skillNode = xml.CreateElement(VisualElement, UI);
                skillNode.SetAttribute("style", $"{Background} {Position} {ImageStyle(node.Skill.Image)}");
                skillNode.SetAttribute("name", node.Skill.Name.Replace(" ", ""));
                container.AppendChild(skillNode);

                foreach (var child in node.Children)
                {
                    XmlElement lineNode = xml.CreateElement("LineElement");
                    lineNode.SetAttribute("name", $"{node.Skill.Name.Replace(" ", "")} -> {child.Skill.Name.Replace(" ", "")}");
                    lineNode.SetAttribute("start-element", node.Skill.Name.Replace(" ", ""));
                    lineNode.SetAttribute("end-element", child.Skill.Name.Replace(" ", ""));
                    lineNode.SetAttribute("style", $"{Position} {Background}");
                    edges.AppendChild(lineNode);
                }                
            }
            
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            XmlSerializer serializer = new (typeof(XmlElement));
            TextWriter writer = new StringWriter();
            
            serializer.Serialize(XmlWriter.Create(writer, settings), el, namespaces);
            return writer.ToString();
        }
    }


}