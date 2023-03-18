namespace CaptainCoder.SkillTree.UnityEngine
{
    public interface IUXMLGenerator<T>
    {
        public string ToUXMLElement(T toConvert);
    }
}