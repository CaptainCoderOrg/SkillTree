using UnityEngine;
using UnityEngine.UIElements;

public class LineElement : VisualElement
{

    public LineElement()
    {
        AddToClassList("unacquired-edge");
        generateVisualContent += OnGenerateVisualContent;
        RegisterCallback<CustomStyleResolvedEvent>(evt => CustomStylesResolved(evt));
    }

    // TODO: Understand the CustomStyleResolvedEvent. Is there an event
    // that specifically is for this.resolvedStyle? Or is this that event
    void CustomStylesResolved(CustomStyleResolvedEvent evt) => MarkDirtyRepaint();

    private bool _acquired;
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

    private Vector2 ToPosition(VisualElement element)
    {
        return new Vector2(element.style.left.value.value, element.style.top.value.value);
    }

    private VisualElement FindRoot(VisualElement current)
    {
        if (current.parent == null) return current;
        return FindRoot(current.parent);
    }

    private void OnGenerateVisualContent(MeshGenerationContext mgc)
    {
        var root = FindRoot(this);
        VisualElement start = root.Q<VisualElement>(StartElement);
        VisualElement end = root.Q<VisualElement>(EndElement);
        Vector2 startVector = start.layout.center;
        Vector2 endVector = end.layout.center;
        var paint2D = mgc.painter2D;
        paint2D.strokeColor = resolvedStyle.color;
        paint2D.lineWidth = 5;
        paint2D.BeginPath();
        paint2D.MoveTo(startVector);
        paint2D.LineTo(endVector);
        paint2D.ClosePath();
        paint2D.Stroke();

    }

    public void Init(string startElement, string endElement, Color lineColor)
    {
        StartElement = startElement;
        EndElement = endElement;
        LineColor = lineColor;
    }

    public string StartElement { get; set; }
    public string EndElement { get; set; }
    public Color LineColor { get; set; }

    public sealed new class UxmlFactory : UxmlFactory<LineElement, UxmlTraits> { }

    public sealed new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription _startElement = new() { name = "start-element", defaultValue = string.Empty };
        UxmlStringAttributeDescription _endElement = new() { name = "end-element", defaultValue = string.Empty };
        UxmlColorAttributeDescription _lineColor = new() { name = "line-color", defaultValue = Color.black };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var line = ve as LineElement;
            string AsString(UxmlStringAttributeDescription e) => e.GetValueFromBag(bag, cc);
            Color AsColor(UxmlColorAttributeDescription e) => e.GetValueFromBag(bag, cc);
            line.Init(AsString(_startElement), AsString(_endElement), AsColor(_lineColor));
        }
    }
}
