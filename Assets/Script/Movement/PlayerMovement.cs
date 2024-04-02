using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new Camera camera;
    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow(maxJumpTime / 2f, 2);

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime; // Mario'nun fiziksel hareketi için

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // Mario'nun hareketini sýnýrlamak için
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        rigidbody.MovePosition(position);
    }

    private void HorizontalMovement() // x ekseninde hareket için
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = inputAxis * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputAxis = context.ReadValue<float>();
    }
}
