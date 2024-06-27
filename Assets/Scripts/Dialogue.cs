using System;
using System.Collections.Generic;
using OneOf;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    static Color FontColour;

    [SerializeField] private TextAsset _storiesAsset;

    private HideChildren _hideChildren;
    private RectTransform _dialogueBackground;
    private TextMeshProUGUI _textmesh;

    private List<Story> _stories;

    private void Awake()
    {
        _hideChildren = GetComponent<HideChildren>();
        _hideChildren.HideAllChildren();
        _dialogueBackground = GetComponentInChildren<RectTransform>();
        _textmesh = _dialogueBackground.GetComponentInChildren<TextMeshProUGUI>();
        FontColour = _textmesh.color;
        Debug.Log(_storiesAsset.text);
        _stories = JsonUtility.FromJson<List<Story>>(_storiesAsset.text);
    }

    private void Update()
    {
        
    }

    public class Story
    {
        string triggerEvent;
        List<OneOf<Content, List<OneOf<Content>>>> content;
    }

    public class Content : OneOfBase<string, StyledContent>
    {
        public Content(OneOf<string, StyledContent> _) : base(_) { }

        public static implicit operator Content(string _) => new Content(_);
        public static implicit operator Content(StyledContent _) => new Content(_);
    }

    public struct StyledContent
    {
        public string text;
        public Style style;

        public StyledContent(string text, Style style)
        {
            this.text = text;
            this.style = style;
        }

        public override readonly string ToString() => $"{style:text}";

        public struct Style
        {
            public bool bold;
            public bool italic;
            public bool underline;
            public Color32 colour;

            public Style(bool bold = false, bool italic = false, bool underline = false, Color32? colour = null)
            {
                this.bold = bold;
                this.italic = italic;
                this.underline = underline;
                this.colour = (Color32)(colour.HasValue ? colour : FontColour);
            }

            public readonly string BoldElement(string inner) => $"{(bold ? "<b>" : "")}{inner}{(bold ? "</b>" : "")}";
            public readonly string ItalicElement(string inner) => $"{(italic ? "<i>" : "")}{inner}{(italic ? "</i>" : "")}";
            public readonly string UnderlineElement(string inner) => $"{(underline ? "<u>" : "")}{inner}{(underline ? "</u>" : "")}";
            public readonly string ColourElement(string inner) => $"<color={ColorUtility.ToHtmlStringRGBA(colour)}>{inner}</color>";

            public readonly string ToString(string inner) => $"{BoldElement(ItalicElement(UnderlineElement(ColourElement(inner))))}";
        }
    }
}
