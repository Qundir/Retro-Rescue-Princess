using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cameras;
    private Collider2D colliders;
    private Vector2 velocity;
    private float inputAxis;
    public float moveSpeed = 8f;
    public float maxJumpHeight = 5.5f;
    public float maxJumpTime = 1f;

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f ),2);

    public bool grounded{get; private set; }
    public bool jumping{get; private set; }
    public bool running => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool sliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);
    PlayerInput playerInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cameras = Camera.main;
        colliders = GetComponent<Collider2D>();
        playerInput = new PlayerInput();
    }
     private void OnEnable()
    {
        rb.isKinematic = false;
        colliders.enabled = true;
        velocity = Vector2.zero;
        jumping = false;
        playerInput.Enable();
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
        colliders.enabled = false;
        velocity = Vector2.zero;
        jumping = false;
        playerInput.Disable();
    }
    private void Update()
    {
        
        HorizontalMovement();
        grounded = rb.Raycast(Vector2.down);

        if(grounded){
            GroundedMovement();
        }
        ApplyGravity();
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;
        //camera
        Vector2 leftEdge = cameras.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = cameras.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp (position.x, leftEdge.x + 7f, rightEdge.x - 0.5f);

        rb.MovePosition(position);
    }

    private void ApplyGravity()
     {
        bool isSpaceKeyHeld = playerInput.Movement.Jump.ReadValue<float>() > 0.1f;
        bool falling = velocity.y < 0f || !isSpaceKeyHeld;
        float multiplier = falling ? 2f : 1f;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
     }

    private void GroundedMovement()
    {
        bool isSpaceKeyHeld = playerInput.Movement.Jump.ReadValue<float>() > 0.1f;
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        if (isSpaceKeyHeld)
        {
            velocity.y = jumpForce;
            jumping = true;
        }
        
    }
    private void HorizontalMovement()
    {
        // accelerate / decelerate
        inputAxis = playerInput.Movement.HorizontalAndTunnel.ReadValue<Vector2>().x;
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);
        if(rb.Raycast(Vector2.right * velocity.x)){
            velocity.x = 0f;
        }
        if(velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (velocity.x < 0f){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            if(transform.DotTest(collision.transform, Vector2.down))
            {
                velocity.y = jumpForce / 2f;
                jumping = true;
            }
        }
        else if(collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            if(transform.DotTest(collision.transform, Vector2.up)){
                velocity.y = 0f;
            }
        }
    }

}
