using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBall : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Hit();
            DestroyBossFireBall();
        }
        else if (collision.gameObject.CompareTag("Fireball"))
        {
            Fireball fireball = collision.gameObject.GetComponent<Fireball>();
            DestroyBossFireBall();
            fireball.DestroyFireball();
            
        }
    }
    public void DestroyBossFireBall()
    {
        Destroy(gameObject);
    }
}
