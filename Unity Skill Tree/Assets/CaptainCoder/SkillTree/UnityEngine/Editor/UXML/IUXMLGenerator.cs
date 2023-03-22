using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public interface IUXMLGenerator<T>
    {
        public XmlElement ToXMLElement(T toConvert);
    }

    public static class UXML 
    {
        public readonly static XmlDocument XML = new ();
        public static string UI => "UnityEngine.UIElements";
        public static string VisualElement => "ui:VisualElement";
        public static readonly string TransparentBackground = "background-color: rgba(0, 0, 0, 0);";
        public static readonly string AbsolutePosition = "position: absolute;";

        public static string SanitizeSkillName(ISkill toSanitize) => toSanitize.Name.Replace(" ", "");
        public static XmlElement CreateVisualElement(string name)
        {
            XmlElement visualElement = XML.CreateElement(VisualElement, UI);
            visualElement.SetAttribute("name", name);
            return visualElement;
        }
        public static XmlElement CreateContainer(string name)
        {
            XmlElement container = CreateVisualElement(name);
            container.SetAttribute("style", $"{TransparentBackground} width:100%; height:100%; {AbsolutePosition}");
            return container;
        }
        public static XmlElement CreateLineElement(ISkill parent, ISkill child)
        { 
            XmlElement lineElement = XML.CreateElement("LineElement");
            string parentName = SanitizeSkillName(parent);
            string childName = SanitizeSkillName(child);
            lineElement.SetAttribute("name", $"{parentName}_{childName}");
            lineElement.SetAttribute("start-element", parentName);
            lineElement.SetAttribute("end-element", childName);
            lineElement.SetAttribute("style", $"{TransparentBackground} {AbsolutePosition}");
            return lineElement;
        }
        public static XmlElement CreateUXMLDocument() => XML.CreateElement("ui:UXML", UI);

        
    }

    public static class IXUMLExtensions
    {
        public static string ToUXMLDocString<T>(this IUXMLGenerator<T> generator, T toConvert)
        {
            XmlSerializerNamespaces namespaces = new ();
            namespaces.Add("ui", UXML.UI);
            XmlElement el = generator.ToXMLElement(toConvert);
            XmlElement doc = UXML.CreateUXMLDocument();
            doc.AppendChild(el);
            XmlWriterSettings settings = new ();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            XmlSerializer serializer = new (typeof(XmlElement));
            TextWriter writer = new StringWriter();            
            serializer.Serialize(XmlWriter.Create(writer, settings), doc, namespaces);
            return writer.ToString();
        }
    }
}