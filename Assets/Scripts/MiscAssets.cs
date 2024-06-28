using System.Collections.Generic;
using UnityEngine;

public class MiscAssets : MonoBehaviour
{
    [SerializeField] private List<TextAsset> _textAssets;

    public TextAsset this[int index]
    {
        get => _textAssets[index];
    }

    public TextAsset this[string name]
    {
        get => _textAssets.Find(x => x.name == name);
    }
}
