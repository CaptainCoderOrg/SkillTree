using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
    [System.Serializable]
    public class SkillData : ScriptableObject, ISkill, IHasRequirements<IPlayerCharacter, SkillData>, ISerializationCallbackReceiver
    {
        [field: SerializeField]
        public string GUID { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public Sprite Image { get; private set; }
        [field: SerializeField]
        public int RequiredLevel { get; private set; } = 1;
        [field: SerializeField]
        public int RequiredSkillPoints { get; private set; } = 1;
        [field: SerializeField]
        public List<SkillRequirementData> AdditionalRequirements { get; private set; }
        
        public IEnumerable<IRequirement<IPlayerCharacter, SkillData>> Requirements 
        {
            get
            {
                List<IRequirement<IPlayerCharacter, SkillData>> requirements = 
                    AdditionalRequirements.Select(c => (IRequirement<IPlayerCharacter, SkillData>)c).ToList();

                requirements.Add(new LevelRequirement(RequiredLevel));
                requirements.Add(new CostRequirement(RequiredSkillPoints));
                return requirements;
            }
        }

        public void OnAfterDeserialize()
        {
            // throw new System.NotImplementedException();
            
        }

        public void OnBeforeSerialize()
        {
            // throw new System.NotImplementedException();
            if (string.IsNullOrEmpty(GUID?.Trim()))
            {
                GUID = Guid.NewGuid().ToString();
            }
        }
    }
}
