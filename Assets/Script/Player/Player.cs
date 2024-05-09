
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public PlayerSpriteRenderer fireRenderer;
    private PlayerSpriteRenderer activeRenderer;



    private DeathAnimation deathAnimation;
    private CapsuleCollider2D capsuleCollider;
    public bool fire => fireRenderer.enabled;
    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;
    public bool dead => deathAnimation.enabled;
    public bool starpower {get; private set;}

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        activeRenderer = smallRenderer;
    }
    public void Hit()
    {
        if(!starpower && !dead)
        {
            if(big){
                Shrink();
            }else{
                Death();
            }
        }
        

    }
    public void GrowFire()
    {
        bigRenderer.enabled = false;
        fireRenderer.enabled = true;
        activeRenderer = fireRenderer;
        GameManager.Instance.AddScore(1000);
        StartCoroutine(ScaleAnimation());
    }
    public void Grow()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
        activeRenderer = bigRenderer;
        GameManager.Instance.AddScore(1000);
        capsuleCollider.size = new Vector2 (1f, 2f);
        capsuleCollider.offset = new Vector2 (0f, 0.5f);
        StartCoroutine(ScaleAnimation());
    }
    private void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;
        activeRenderer = smallRenderer;

        capsuleCollider.size = new Vector2 (1f, 1f);
        capsuleCollider.offset = new Vector2 (0f, 0f);
        StartCoroutine(ScaleAnimation());
    }
    private void Death(){
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        deathAnimation.enabled = true;
        //make revive etc here
        GameManager.Instance.ResetLevel(3f);
    }
    
    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            if(Time.frameCount %4 == 0)
            {
                smallRenderer.enabled = !smallRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }

            yield return null;
        }

        smallRenderer.enabled = false;
        bigRenderer.enabled = false;

        activeRenderer.enabled = true;
    }
    
    public void StarPower(float duration = 10f)
    {
        StartCoroutine(StarpowerAnimation(duration));
    }

    private IEnumerator StarpowerAnimation(float duration)
    {
        GameManager.Instance.AddScore(2000);

        starpower = true;

        float elapsed = 0f;
    
        while (elapsed < duration )
        {
            elapsed += Time.deltaTime;
            if (Time.frameCount % 4 == 0)
            {
                activeRenderer.spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f,1f);
            }
            yield return null;
        }

        activeRenderer.spriteRenderer.color = Color.white;

        starpower = false;
    }
}
