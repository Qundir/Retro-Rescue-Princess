using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class EntityMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public Vector2 direction = Vector2.left;
    public float speed = 2f;
    private Vector2 velocity;
    //daily contribituon
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        enabled = false;
    }
    private void OnEnable()
    {
        rigidbody.WakeUp();
    }
    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y = Physics2D.gravity.y * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        if(rigidbody.Raycast(direction))
        {
            direction = -direction;
        }
        if (rigidbody.Raycast(Vector2.down)){
            velocity.y = Mathf.Max(velocity.y, 0f);
        }
    }
}
