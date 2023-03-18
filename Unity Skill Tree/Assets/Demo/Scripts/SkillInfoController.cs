using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public class SkillInfoController : MonoBehaviour
    {
        [field: SerializeField]
        public UIDocument SkillLayout { get; private set; }
        private Label _skillName;
        private Label _skillDescription;

        public void Awake()
        {
            VisualElement root = SkillLayout.rootVisualElement;
            _skillName = root.Q<Label>("SkillName");
            Debug.Assert(_skillName != null, "Could not find SkillName node.");
            _skillDescription = root.Q<Label>("SkillDescription");
            Debug.Assert(_skillDescription != null, "Could not find SkillDescription node.");
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
            _skillName.text = selected.DisplayName;
            _skillDescription.text = selected.DisplayDescription;
        }
    }
}
