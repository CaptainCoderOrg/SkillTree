using System.Xml;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillTreeDeserializer
    {
        public static SkillTreeDeserializer Default = new();

        public ISkillTreeMetaData ParseMetaData(string path)
        {
            if (!File.Exists(path)) { throw new FileNotFoundException($"Could not load metadata {path}"); }
            XmlDocument doc = new();
            doc.Load(path);
            SkillTreeMetaData metaData = new();
            ScanDocument(doc.DocumentElement, metaData);
            return metaData;
        }

        private void ScanDocument(XmlElement node, SkillTreeMetaData accumulator)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType != XmlNodeType.Element) { continue; }
                XmlElement childElement = (XmlElement)child;
                ScanDocument(childElement, accumulator);
                if (childElement.Name != SkillNodeGenerator.s_SkillNodeElement) { continue; }
                string name = childElement.GetAttribute("name");
                Debug.Assert(name != string.Empty, "Discovered SkillNode without a name attribute.");
                string style = childElement.GetAttribute("style");
                Match leftMatch = Regex.Match(style, "left: [0-9]+px;");
                Match topMatch = Regex.Match(style, "top: [0-9]+px;");
                int x = leftMatch.Success ? ExtractInt(leftMatch) : 0;
                int y = topMatch.Success ? ExtractInt(topMatch) : 0;
                accumulator._positions[name] = new Vector2(x, y);
                Debug.Log($"{name}: {x} {y}");
            }
        }

        private int ExtractInt(Match match) 
            => int.Parse(Regex.Match(match.Groups[0].Value, "[0-9]+").Groups[0].Value, 
                         CultureInfo.InvariantCulture);

        private class SkillTreeMetaData : ISkillTreeMetaData
        {
            internal Dictionary<string, Vector2> _positions = new();
            public Vector2 PositionOf(string skillName)
            {
                if (_positions.TryGetValue(skillName, out Vector2 result))
                {
                    return result;
                }
                return new Vector2(0, 0);
            }
        }
    }

    public interface ISkillTreeMetaData
    {
        public Vector2 PositionOf(string skillName) => Vector2.zero;

        public static ISkillTreeMetaData Default = new DefaultMetaData();

        private class DefaultMetaData : ISkillTreeMetaData {};
    }


}