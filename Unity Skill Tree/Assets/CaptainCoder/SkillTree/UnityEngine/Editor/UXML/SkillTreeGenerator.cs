using System.Xml;
using UnityEngine;
using UnityEditor;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillTreeGenerator : IUXMLGenerator<ScriptableSkillTree>
    {
        public XmlElement ToXMLElement(ScriptableSkillTree toConvert)
        {
            XmlElement el = UXML.CreateContainer("SkillTree");

            XmlElement edges = UXML.CreateContainer("Edges");
            el.AppendChild(edges);

            XmlElement nodes = UXML.CreateContainer("Nodes");
            el.AppendChild(nodes);

            SkillNodeGenerator generator = new(edges);
            foreach (var node in toConvert.SkillTree.Nodes)
            {
                nodes.AppendChild(generator.ToXMLElement(node));
            }

            return el;
        }
    }
}