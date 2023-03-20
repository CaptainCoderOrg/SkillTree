using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    [CreateAssetMenu(fileName = "SkillDatabase", menuName = "Skills/Database")]
    public class SkillDatabase : ScriptableObject, ISkillDatabase
    {
        private Dictionary<string, SkillData> _skillLookup;
        private Dictionary<string, GameSkillTreeData> _skillTreeLookup;
        private Dictionary<string, SkillData> SkillLookup => _skillLookup ??= InitializeSkills();
        private Dictionary<string, GameSkillTreeData> SkillTreeDatabase => _skillTreeLookup ??= InitializeSkillTrees();
        [SerializeField]
        private List<SkillData> _skills;
        [SerializeField]
        private List<GameSkillTreeData> _skillTrees;
        public ISkill LookupSkill(string guid) => SkillLookup[guid];
        public GameSkillTreeData LookupTree(string guid) => SkillTreeDatabase[guid];

        private void OnEnable() {
            InitializeSkills();
            InitializeSkillTrees();
        }

        private Dictionary<string, GameSkillTreeData> InitializeSkillTrees()
        {
            _skillTreeLookup = new Dictionary<string, GameSkillTreeData>();
            foreach (GameSkillTreeData tree in _skillTrees)
            {
                if (tree.GUID == null)
                {
                    Debug.LogError("Detected null GUID while deserializing SkillDatabase.");
                    continue;
                }
                if (_skillTreeLookup.ContainsKey(tree.GUID))
                {
                    throw new System.InvalidOperationException($"Detected duplicate GUID on Skills: {tree.Name} and {_skillTreeLookup[tree.GUID].Name}.");
                }
                _skillTreeLookup[tree.GUID] = tree;
            }
            return _skillTreeLookup;
        }

        private Dictionary<string, SkillData> InitializeSkills()
        {
            _skillLookup = new Dictionary<string, SkillData>();
            foreach (SkillData skill in _skills)
            {
                if (skill.GUID == null)
                {
                    Debug.LogError("Detected null GUID while deserializing SkillDatabase.");
                    continue;
                }
                if (_skillLookup.ContainsKey(skill.GUID))
                {
                    throw new System.InvalidOperationException($"Detected duplicate GUID on Skills: {skill.Name} and {_skillLookup[skill.GUID].Name}.");
                }
                _skillLookup[skill.GUID] = skill;
            }
            return _skillLookup;
        }
    }
}
