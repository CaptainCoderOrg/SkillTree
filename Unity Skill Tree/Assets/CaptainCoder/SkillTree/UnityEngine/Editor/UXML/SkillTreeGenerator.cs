using System.Xml;
using UnityEngine;
using UnityEditor;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillTreeGenerator : IUXMLGenerator<ScriptableSkillTree>
    {
        private readonly ISkillTreeMetaData _metaData;
        public SkillTreeGenerator(ISkillTreeMetaData metaData)
            => (_metaData) = (metaData);
        public XmlElement ToXMLElement(ScriptableSkillTree toConvert)
        {
            XmlElement el = UXML.CreateContainer("SkillTree");
            el.SetAttribute("skill-tree-guid", toConvert.GUID);

            XmlElement edges = UXML.CreateContainer("Edges");
            el.AppendChild(edges);

            XmlElement nodes = UXML.CreateContainer("Nodes");
            el.AppendChild(nodes);

            SkillNodeGenerator generator = new(toConvert.GUID, _metaData, edges);
            foreach (var node in toConvert.SkillTree.Nodes)
            {
                nodes.AppendChild(generator.ToXMLElement(node));
            }

            return el;
        }
    }
}