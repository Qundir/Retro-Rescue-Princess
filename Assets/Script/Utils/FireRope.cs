using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRope : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Hit();
        }
    }
}
