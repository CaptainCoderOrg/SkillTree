using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineElement : VisualElement
{

    public LineElement()
    {
        generateVisualContent += OnGenerateVisualContent;
    }

    private Vector2 ToPosition(VisualElement element)
    {
        return new Vector2(element.style.left.value.value, element.style.top.value.value);
    }
    

    private void OnGenerateVisualContent(MeshGenerationContext mgc)
    {
        VisualElement start = parent.Q<VisualElement>(StartElement);
        Debug.Log(start.name);
        VisualElement end = parent.Q<VisualElement>(EndElement);
        Vector2 startVector = start.layout.center;
        Vector2 endVector = end.layout.center;
        Debug.Log($"Start: {startVector} -> End: {endVector}");
        Debug.Log("Generating!");
        var paint2D = mgc.painter2D;
        paint2D.strokeColor = Color.red;
        paint2D.lineWidth = 5;
        paint2D.BeginPath();
        paint2D.MoveTo(startVector);
        paint2D.LineTo(endVector);
        paint2D.ClosePath();
        paint2D.Stroke();
    }

    public void Init(string startElement, string endElement)
    {
        StartElement = startElement;
        EndElement = endElement;
    }

    public string StartElement { get; set; }
    public string EndElement { get; set; }

    public sealed new class UxmlFactory : UxmlFactory<LineElement, UxmlTraits> { }

    public sealed new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription _startElement = new() { name = "start-element", defaultValue = string.Empty };
        UxmlStringAttributeDescription _endElement = new() { name = "end-element", defaultValue = string.Empty };
        // UxmlIntAttributeDescription _columns = new() { name = "columns", defaultValue = 10 };
        // UxmlIntAttributeDescription _rows = new() { name = "rows", defaultValue = 4 };
        // UxmlIntAttributeDescription _cellSize = new() { name = "cell-size", defaultValue = 32 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var line = ve as LineElement;
            string AsString(UxmlStringAttributeDescription e) => e.GetValueFromBag(bag, cc);
            line.Init(AsString(_startElement), AsString(_endElement));
        }
    }
}
