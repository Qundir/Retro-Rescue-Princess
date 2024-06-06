using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if(player.starpower)
            {
                Hit();
            }else if(other.transform.DotTest(transform, Vector2.down))
            {
                Hit();
            }
            else{

                player.Hit();
            }
        }
    }
    public void Hit()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        GetComponent<BirdieMovement>().enabled = false;
        Destroy(gameObject, 3f);
        GameManager.Instance.AddScore(800);
    }
}
