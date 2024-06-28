using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Interaction> interactions;

    private Character _character;
    public Character Character { get => _character; set => _character = value; }

    private void Awake()
    {
        _character = GetComponent<Character>();
    }
}
