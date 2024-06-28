using OneOf;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Scene? _nextScene;
    [SerializeField] private Vector3? _nextPosition;

    private OneOf<Scene, Vector3> _next;

    private void Awake()
    {
        if (_nextScene.HasValue)
        {
            _next = _nextScene.Value;
        }
        else if (_nextPosition.HasValue)
        {
            _next = _nextPosition.Value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show prompt "Press `e` to <interact>"
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(Actions.INTERACT_KEY))
        {

        }
    }
}
