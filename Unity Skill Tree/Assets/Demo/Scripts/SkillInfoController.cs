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
        }

        private void AddListeners(VisualElement toScan)
        {
            if (toScan is SkillNodeElement)
            {
                SkillNodeElement asSkillNode = toScan as SkillNodeElement;
                asSkillNode.OnClicked += OnSelect;
            }
            foreach (VisualElement child in toScan.Children())
            {
                AddListeners(child);
            }
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
