using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Vector2 _mapBounds = new Vector2(10, 10);

    private Rigidbody _rb;
    private Vector3 _input;
    private bool _shouldJump;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.interpolation = RigidbodyInterpolation.Interpolate;
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        _input = new Vector3(moveX, 0, moveZ).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _shouldJump = true;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();

        if (_shouldJump)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        Vector3 nextPosition = _rb.position + _input * _speed * Time.fixedDeltaTime;

        float clampedX = Mathf.Clamp(nextPosition.x, -_mapBounds.x, _mapBounds.x);
        float clampedZ = Mathf.Clamp(nextPosition.z, -_mapBounds.y, _mapBounds.y);

        Vector3 finalPosition = new Vector3(clampedX, nextPosition.y, clampedZ);

        _rb.MovePosition(finalPosition);
    }

    private void Jump()
    { 
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _shouldJump = false;
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(_rb.velocity.y) < 0.01f;
    }
}