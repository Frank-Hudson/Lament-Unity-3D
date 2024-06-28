using UnityEngine;

public class EntityData : MonoBehaviour
{
    private Character _character;
    public Character Character { get => _character; set => _character = value; }

    private void Awake()
    {
        _character = GetComponent<Character>();
    }
}
