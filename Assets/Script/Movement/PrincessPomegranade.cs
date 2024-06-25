using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessPomegranade : MonoBehaviour
{
    public Sprite giveFlower;

    public void GiveFlowerToEuario()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = giveFlower;
    }
}
