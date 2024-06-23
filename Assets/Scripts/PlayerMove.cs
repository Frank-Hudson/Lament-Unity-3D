using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float SPEED_MODIFIER = 100f; // Without, player will barely move pixels at a time

    [SerializeField] private float _speed = 10f;
    public float Speed { get => _speed * SPEED_MODIFIER; }

    private float _inputHorizontal;
    private float _inputVertical;
    private Vector3 _latestMovement;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");

        bool wKey = Input.GetKey(KeyCode.W);
        bool sKey = Input.GetKey(KeyCode.S);
        bool aKey = Input.GetKey(KeyCode.A);
        bool dKey = Input.GetKey(KeyCode.D);

        _latestMovement = new Vector3(_inputHorizontal, 0f, _inputVertical).normalized * Speed * Time.deltaTime;

        _rigidbody.velocity = _latestMovement;
    }
}
