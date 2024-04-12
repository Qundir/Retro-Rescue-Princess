using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    private DeathAnimation deathAnimation;
    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;
    public bool dead => deathAnimation.enabled;
    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }
    public void Hit()
    {
        if(big){
            Shrink();
        }else{
            Death();
        }

    }

    private void Shrink()
    {
        //TODO
    }
    private void Death(){
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        deathAnimation.enabled = true;
        //make revive etc here
        GameManager.Instance.ResetLevel(3f);
    }
}
