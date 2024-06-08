using Unity.VisualScripting;
using UnityEngine;

public class JumperKoopa : MonoBehaviour
{
    public Sprite shellSprite;
    public bool shelled;
    public bool pushed;
    public bool Jumper = true;
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
            
        }else if(pushed && other.gameObject.CompareTag ("Koopa"))
        {

            Koopa koopa = other.GetComponent<Koopa>();
            FloatingKoopa floatingKoopa = other.GetComponent<FloatingKoopa>();
            JumperKoopa jumperKoopa = other.GetComponent<JumperKoopa>();
            if(koopa != null)
            {
                koopa.Hit();
            }else if(floatingKoopa != null)
            {
                floatingKoopa.Hit();
            }else if(jumperKoopa != null)
            {
                jumperKoopa.Hit();
            }
        }
    }
    private void EnterShell()
    {
        Jumper = false;
        shelled = true;
        GetComponent<JumpKoopa>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shellSprite;

        // shellSprite pozisyonunu ayarla
        Vector3 position = spriteRenderer.transform.localPosition;
        position.y -= 0.35f;
        spriteRenderer.transform.localPosition = position;

        GameManager.Instance.AddScore(400);
    }
    private void PushShell(Vector2 direction)
    {
        pushed = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        JumpKoopa movement = GetComponent<JumpKoopa>();
        movement.enabled = true;
        movement.direction = direction.normalized;
        movement.speed = shellSpeed;
        gameObject.layer = LayerMask.NameToLayer("Shell");
    }
    public void Hit()
    {
        JumpKoopa jumpKoopa = GetComponent<JumpKoopa>();
        if(jumpKoopa != null)
        {
            jumpKoopa.enabled = false;
        }
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
