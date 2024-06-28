using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    public Vector3 StartsAt { get => _startPosition; }

    private void Start()
    {
        transform.position = _startPosition;
    }
}
