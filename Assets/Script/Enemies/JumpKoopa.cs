using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKoopa : MonoBehaviour
{
    public float jumpForce = 6f;
    public float moveSpeed = 3f;
    public float jumpInterval = 0f; 
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float nextJumpTime = 0f;
    public Vector2 direction = Vector2.left;
    public float speed = 2f;
    private Vector2 velocity;
    private JumperKoopa jumperKoopa;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        jumperKoopa = GetComponent<JumperKoopa>();
    }

    private void Start()
    {
        
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }
    private void FixedUpdate()
    {
        if(jumperKoopa.Jumper)
        {

            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
            if (isGrounded && Time.time >= nextJumpTime)
        {
            Jump();
            nextJumpTime = Time.time + jumpInterval;
        }
            if (direction.x > 0f) {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            } else if (direction.x < 0f) {
                transform.localEulerAngles = Vector3.zero;
            }
        }else if(jumperKoopa.pushed)
        {
            velocity.x = direction.x * speed;
            velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

            if (rb.Raycast(direction)) {
                direction = -direction;
            }

            if (rb.Raycast(Vector2.down)) {
                velocity.y = Mathf.Max(velocity.y, 0f);
            }

            if (direction.x > 0f) {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            } else if (direction.x < 0f) {
                transform.localEulerAngles = Vector3.zero;
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if(collision.gameObject.CompareTag("HardBlock") || collision.gameObject.CompareTag("Tunnel"))
        {
            direction = -direction;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnEnable()
    {
        rb.WakeUp();
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.Sleep();
    }
}
