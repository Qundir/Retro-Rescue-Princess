using UnityEngine;
using UnityEngine.Purchasing;

public class Fireball : MonoBehaviour
{
    public float jumpForce = 5f; // Zıplama kuvveti
    public float bounceForce = 3f; // Sekme kuvveti
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zemin veya engel ile temas edildiğinde
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Fireball yukarı doğru bir kuvvet uygula (zıplama)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Fireball yatay eksende zıplama sonrası bir miktar sekme kuvveti uygula
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * bounceForce, ForceMode2D.Impulse);
        }else if(collision.gameObject.CompareTag("Koopa"))
        {
            Koopa koopa = collision.gameObject.GetComponent<Koopa>();
            FloatingKoopa floatingKoopa = collision.gameObject.GetComponent<FloatingKoopa>();
            if(koopa != null)
            {
            koopa.Hit();
            }else if (floatingKoopa != null){
                floatingKoopa.Hit();
            }
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Goomba")){
            Goomba goomba = collision.gameObject.GetComponent<Goomba>();
            goomba.Hit();
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("KoopaBoss"))
        {
            BossKoopa bossKoopa = collision.gameObject.GetComponent<BossKoopa>();
            bossKoopa.Hit();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DestroyFireball()
    {
        Destroy(gameObject);
        Debug.Log("DestroyFireball worked");
    }
}
