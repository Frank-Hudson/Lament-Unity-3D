using System;
using System.Collections.Generic;
using OneOf;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    static Color FontColour;

    [SerializeField] private TextAsset _storiesAsset;
    [SerializeField] private RectTransform _dialogueBackground;
    [SerializeField] private TextMeshProUGUI _textmesh;

    private HideChildren _hideChildren;

    private List<Story> _stories;

    private void Awake()
    {
        _hideChildren = GetComponent<HideChildren>();
        _hideChildren.HideAllChildren();
        FontColour = _textmesh.color;
        Debug.Log(_storiesAsset.text);
        _stories = JsonUtility.FromJson<List<Story>>(_storiesAsset.text);
    }

    private void Update()
    {

    }

    [Serializable]
    public class Story
    {
        string triggerEvent;
        List<OneOf<Content, List<OneOf<Content>>>> content;
    }

    [Serializable]
    public class Content : OneOfBase<string, StyledContent>
    {
        public Content(OneOf<string, StyledContent> _) : base(_) { }

        public static implicit operator Content(string _) => new Content(_);
        public static implicit operator Content(StyledContent _) => new Content(_);
    }

    [Serializable]
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

        [Serializable]
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
