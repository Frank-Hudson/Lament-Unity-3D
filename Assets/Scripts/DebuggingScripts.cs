using Unity.VisualScripting;
using UnityEngine;

public class DebuggingScripts : MonoBehaviour
{
    public const float CAMERA_SPEED = 10;

    [SerializeField] private bool _enableDebug = false;
    [SerializeField] private bool _enableCameraMovement = false;

    private Vector2 _initialHoldPoint;
    private Vector2 _holdPoint;
    private Vector2 _endPoint;

    private void Update()
    {
        if (!_enableDebug) return;

        if (_enableCameraMovement)
        {
            if (Input.GetMouseButtonDown((int)MouseButton.Left))
            {
                _initialHoldPoint = Input.mousePosition;
            }

            if (Input.GetMouseButton((int)MouseButton.Left))
            {
                _holdPoint = Input.mousePosition;
                Vector2 dragDelta = Camera.main.ScreenToViewportPoint(-(_holdPoint - _initialHoldPoint));
                _initialHoldPoint = _holdPoint;

                Camera.main.transform.Translate(dragDelta * CAMERA_SPEED);
            }

            if (Input.GetMouseButtonUp((int)MouseButton.Left))
            {
                _endPoint = Input.mousePosition;
            }

            Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
        }
    }
}
