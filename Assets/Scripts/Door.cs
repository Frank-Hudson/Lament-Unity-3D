using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Bounds _bounds;
    [SerializeField] private string _nextSceneName;
    [SerializeField] private Vector3 _nextCameraPosition;
    [SerializeField] private Vector3 _nextPlayerPosition;

    private void Update()
    {
        if (_player == null) return;

        if (!_bounds.Contains(_player.transform.position))
        {
            foreach (Transform child in transform)
            {
                Canvas canvas = child.gameObject.GetComponent<Canvas>();

                if (canvas != null) canvas.gameObject.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKey(ActionAssets.INTERACT_KEY))
            {
                if (_nextSceneName != null && _nextSceneName != "")
                {
                    SceneManager.LoadScene(_nextSceneName);
                }
                else
                {
                    if (_nextCameraPosition != null)
                    {
                        Camera.main.transform.position = _nextCameraPosition;
                    }
                    if (_nextPlayerPosition != null)
                    {
                        _player.transform.position = _nextPlayerPosition;
                    }
                }
            }

            foreach (Transform child in transform)
            {
                Canvas canvas = child.gameObject.GetComponent<Canvas>();

                if (canvas != null) canvas.gameObject.SetActive(true);
            }
        }
    }
}

[Serializable]
internal struct Bounds
{
    public Vector3 Lower;
    public Vector3 Upper;

    public Bounds(Vector3 lower, Vector3 upper)
    {
        Lower = lower;
        Upper = upper;
    }

    public bool Contains(Vector3 value) =>
        Lower.x < value.x && value.x < Upper.x &&
        Lower.y < value.y && value.y < Upper.y &&
        Lower.z < value.z && value.z < Upper.z;

    public static implicit operator (Vector3, Vector3)(Bounds box) => (box.Lower, box.Upper);
    public static implicit operator Bounds((Vector3, Vector3) box) => new Bounds(box.Item1, box.Item2);
}
