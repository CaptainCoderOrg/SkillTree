using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class SkillNodeElement : VisualElement
    {
        public event Action<SkillNodeElement> OnPointerEntered;
        public event Action<SkillNodeElement> OnClicked;

        public SkillNodeElement()
        {
            RegisterCallback<PointerDownEvent>(OnPointerDown);
            RegisterCallback<PointerEnterEvent>(OnPointerEnter);
        }

        private void OnPointerEnter(PointerEnterEvent evt) => OnPointerEntered?.Invoke(this);
        private void OnPointerDown(PointerDownEvent evt) => OnClicked?.Invoke(this);

        private void Init(string name, string description) => (DisplayName, DisplayDescription) = (name, description);

        public string DisplayName { get; set; }
        public string DisplayDescription { get; set; }

        public sealed new class UxmlFactory : UxmlFactory<SkillNodeElement, UxmlTraits> { }

        public sealed new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription _displayName = new() { name = "display-name", defaultValue = string.Empty };
            UxmlStringAttributeDescription _displayDescription = new() { name = "display-description", defaultValue = string.Empty };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var skillNode = ve as SkillNodeElement;
                string AsString(UxmlStringAttributeDescription e) => e.GetValueFromBag(bag, cc);
                skillNode.Init(AsString(_displayName), AsString(_displayDescription));
            }
        }

    }
}
