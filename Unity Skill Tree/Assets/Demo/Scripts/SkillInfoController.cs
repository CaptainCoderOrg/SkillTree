using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public class SkillInfoController : MonoBehaviour
    {
        [field: SerializeField]
        public SkillDatabase Database { get; private set; }
        [field: SerializeField]
        public UIDocument SkillLayout { get; private set; }
        [field: SerializeField]
        public PlayerCharacter Player { get; private set; }
        private Label _skillName;
        private Label _skillDescription;
        private Button _buyButton;
        private ISkillNode<IPlayerCharacter, SkillData> _selectedNode;

        public void Awake()
        {
            VisualElement root = SkillLayout.rootVisualElement;
            _skillName = root.Q<Label>("SkillName");
            Debug.Assert(_skillName != null, "Could not find SkillName node.");
            _skillDescription = root.Q<Label>("SkillDescription");
            Debug.Assert(_skillDescription != null, "Could not find SkillDescription node.");
            _buyButton = root.Q<Button>("BuyButton");
            _buyButton.clicked += BuySkill;
            _buyButton.SetEnabled(false);
            AddListeners(root);
            Player.OnSkillAcquired += HandleSkillsChanged;
        }

        private void HandleSkillsChanged(string acquired, HashSet<string> skills)
        {
            Debug.Log($"Acquired: {acquired}");
            if (_skillChange.TryGetValue(acquired, out var handlers))
            {
                Debug.Log($"Found {handlers.Count} possible edges.");
                foreach (var handler in handlers)
                {
                    handler.Invoke(skills);
                }
            }
        }

        private readonly Dictionary<string, List<System.Action<HashSet<string>>>> _skillChange = new();

        private List<System.Action<HashSet<string>>> EdgeActions(string start)
        {
            if (!_skillChange.TryGetValue(start, out var list))
            {
                list = new List<System.Action<HashSet<string>>>();
                _skillChange[start] = list;
            }
            return list;
        }

        private void AddListeners(VisualElement toScan)
        {
            if (toScan is SkillNodeElement skillNode)
            {
                skillNode.OnClicked += OnSelect;
            }
            if (toScan is LineElement lineElement)
            {
                Debug.Log("Registering line element");
                (SkillNodeElement start, SkillNodeElement end) = lineElement.Nodes;
                AddEdgeAction(start, end, lineElement);
                AddEdgeAction(end, start, lineElement);

            }
            foreach (VisualElement child in toScan.Children())
            {
                AddListeners(child);
            }
        }

        private void AddEdgeAction(SkillNodeElement start, SkillNodeElement end, LineElement lineElement)
        {
            var actions = EdgeActions(start.SkillGuid);
            void CheckHighlightEdgeAction(HashSet<string> skillGuids)
            {
                if (skillGuids.Contains(end.SkillGuid))
                {
                    lineElement.Acquired = true;
                }
            };
            actions.Add(CheckHighlightEdgeAction);
        }

        private void OnSelect(SkillNodeElement selected)
        {
            ISkill skill = Database.LookupSkill(selected.SkillGuid);
            GameSkillTreeData skillTree = Database.LookupTree(selected.SkillTreeGuid);
            _selectedNode = skillTree.BuildSkillTree().GetNode(skill as SkillData);
            _buyButton.SetEnabled(_selectedNode.CheckRequirements(Player));
            _skillName.text = skill.Name;
            _skillDescription.text = skill.Description;
        }

        private void BuySkill()
        {
            Player.AcquireSkill(_selectedNode);
        }
    }
}
