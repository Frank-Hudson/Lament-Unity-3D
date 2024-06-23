using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private const float JUMP_MODIFIER = 40f; // Without, player will barely move pixels at a time

    [SerializeField] private float _jump = 36f;
    public float Jump { get => _jump * JUMP_MODIFIER; }

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool spaceKey = Input.GetKey(KeyCode.Space);

        if (spaceKey)
        {
            _rigidbody.AddForce(Vector3.up * Jump * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
