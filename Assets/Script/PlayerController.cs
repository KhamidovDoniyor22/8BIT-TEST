using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Vector2 mapBounds = new Vector2(10, 10);

    private Rigidbody _rb;
    private Vector3 _input;

    void Awake() => _rb = GetComponent<Rigidbody>();

    void Update()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rb.velocity.y) < 0.01f)
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + _input * speed * Time.fixedDeltaTime);

        // Ограничение по карте
        float clampedX = Mathf.Clamp(transform.position.x, -mapBounds.x, mapBounds.x);
        float clampedZ = Mathf.Clamp(transform.position.z, -mapBounds.y, mapBounds.y);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}