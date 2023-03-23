using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public class LineElement : VisualElement
    {
        private SkillNodeElement _startNode;
        private SkillNodeElement _endNode;
        private bool _acquired;

        public LineElement()
        {
            Acquired = false;
            generateVisualContent += OnGenerateVisualContent;
            RegisterCallback<CustomStyleResolvedEvent>(evt => CustomStylesResolved(evt));
        }

        public string StartElement { get; set; }
        public string EndElement { get; set; }
        public (SkillNodeElement start, SkillNodeElement end) Nodes => InitNodes();
        public bool Acquired
        {
            get => _acquired;
            set
            {
                _acquired = value;
                if (_acquired)
                {
                    AddToClassList("acquired-edge");
                    RemoveFromClassList("unacquired-edge");
                }
                else
                {
                    RemoveFromClassList("acquired-edge");
                    AddToClassList("unacquired-edge");
                }
            }
        }

        private void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            InitNodes();
            Vector2 startVector = _startNode.layout.center;
            Vector2 endVector = _endNode.layout.center;
            var paint2D = mgc.painter2D;
            paint2D.strokeColor = resolvedStyle.color;
            paint2D.lineWidth = 5;
            paint2D.BeginPath();
            paint2D.MoveTo(startVector);
            paint2D.LineTo(endVector);
            paint2D.ClosePath();
            paint2D.Stroke();
        }

        // TODO: Understand the CustomStyleResolvedEvent. Is there an event
        // that specifically is for this.resolvedStyle? Or is this that event
        private void CustomStylesResolved(CustomStyleResolvedEvent evt) => MarkDirtyRepaint();

        private Vector2 ToPosition(VisualElement element) => new(element.style.left.value.value, element.style.top.value.value);

        private VisualElement FindRoot(VisualElement current)
        {
            if (current.parent == null) return current;
            return FindRoot(current.parent);
        }

        private (SkillNodeElement, SkillNodeElement) InitNodes()
        {
            if (_startNode != null) { return (_startNode, _endNode); }
            var root = FindRoot(this);
            _startNode = root.Q<SkillNodeElement>(StartElement);
            _endNode = root.Q<SkillNodeElement>(EndElement);
            Debug.Assert(_startNode != null);
            Debug.Assert(_endNode != null);
            return (_startNode, _endNode);
        }

        private void Init(string startElement, string endElement)
        {
            StartElement = startElement;
            EndElement = endElement;
        }

        public sealed new class UxmlFactory : UxmlFactory<LineElement, UxmlTraits> { }

        public sealed new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription _startElement = new() { name = "start-element", defaultValue = string.Empty };
            UxmlStringAttributeDescription _endElement = new() { name = "end-element", defaultValue = string.Empty };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var line = ve as LineElement;
                string AsString(UxmlStringAttributeDescription e) => e.GetValueFromBag(bag, cc);
                line.Init(AsString(_startElement), AsString(_endElement));
            }
        }
    }
}