using Unity.VisualScripting;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;
    private bool shelled;
    private bool pushed;

    public float shellSpeed = 12f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.starpower)
            {
                Hit();
            }
            if(collision.transform.DotTest(transform, Vector2.down))
            {
                EnterShell();
            }else{
                player.Hit();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(shelled && other.CompareTag("Player"))
        {
            if(!pushed)
            {
                Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                PushShell(direction);
            }else
            {
                Player player = other.GetComponent<Player>();
                if(player.starpower){
                    Hit();
                }else{
                player.Hit();

                }
            }
        }
        else if(!shelled && other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }
    private void EnterShell()
    {
        shelled = true;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;
        GameManager.Instance.AddScore(400);
    }
    private void PushShell(Vector2 direction)
    {
        pushed = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        EntityMovement movement = GetComponent<EntityMovement>();
        movement.direction = direction.normalized;
        movement.speed = shellSpeed;
        movement.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Shell");
    }
    public void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
        GameManager.Instance.AddScore(600);
    }

    private void DestroyKoopa()
    {
        Destroy(gameObject);
    }
    private void OnBecameInvisible(){
        if (pushed)
            Invoke(nameof(DestroyKoopa), 3.0f);

    }
    private void OnBecameVisible()
    {
        if(pushed)
        CancelInvoke(nameof(DestroyKoopa));
    }
}
