using CaptainCoder.SkillTree;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class ScriptableSkillTree : ScriptableObject, ISerializationCallbackReceiver
    {
        [field: SerializeField]
        public string GUID { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        public virtual ISkillTree<ISkilledEntity<ISkill>, ISkill> SkillTree => throw new System.NotImplementedException("SkillTree property must be overridden in subclass");

        public void OnBeforeSerialize()
        {
            // throw new System.NotImplementedException();
            if (string.IsNullOrEmpty(GUID?.Trim()))
            {
                Debug.Log("Generating GUID for ScriptableSkillTree", this);
                GUID = System.Guid.NewGuid().ToString();
            }
        }

        public void OnAfterDeserialize()
        {

        }
    }
}