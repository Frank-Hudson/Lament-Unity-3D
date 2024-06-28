using System;
using UnityEngine;

[Serializable]
public class Character : MonoBehaviour
{
    [SerializeField] private TextAsset _characterAsset;
    [SerializeField] private CharacterData _characterData;
    public CharacterData CharacterData { get => _characterData; set => _characterData = value; }

    private void Awake()
    {
        _characterData = JsonUtility.FromJson<CharacterData>(_characterAsset.text);
    }
}
