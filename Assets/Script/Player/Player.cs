
using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public PlayerSpriteRenderer fireRenderer;
    public PlayerSpriteRenderer activeRenderer;
    private DeathAnimation deathAnimation;
    private CapsuleCollider2D capsuleCollider;
    public bool fire => fireRenderer.enabled;
    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;
    public bool dead => deathAnimation.enabled;
    public bool starpower {get; private set;}
    public GameObject fireBall;
    public Transform firePoint;
    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        SetRenderer(GameManager.Instance.activeRendererType);
    }
   public void SetRenderer(string rendererType)
    {
        switch (rendererType)
        {
            case "Small":
                activeRenderer = smallRenderer;
                smallRenderer.enabled = true;
                bigRenderer.enabled = false;
                fireRenderer.enabled = false;
                capsuleCollider.size = new Vector2 (1f, 1f);
                capsuleCollider.offset = new Vector2 (0f, 0f);
                break;
            case "Big":
                activeRenderer = bigRenderer;
                fireRenderer.enabled = false;
                smallRenderer.enabled = false;
                bigRenderer.enabled = true;
                capsuleCollider.size = new Vector2 (1f, 1.5f);
                capsuleCollider.offset = new Vector2 (0f, 0.25f);
                break;
            case "Fire":
                activeRenderer = fireRenderer;
                smallRenderer.enabled = false;
                bigRenderer.enabled = false;
                fireRenderer.enabled = true;
                capsuleCollider.size = new Vector2 (1f, 1.5f);
                capsuleCollider.offset = new Vector2 (0f, 0.25f);
                break;
        }
        GameManager.Instance.StoreRendererType(rendererType);  // Store the current type in GameManager
    }
    public void Hit()
    {
        if(!starpower && !dead)
        {
            if(big || fire){
                Shrink();
            }else{
                Death();
            }
        }
    }
    public void ShotFireBall()
    {
        if(activeRenderer == fireRenderer)
        {
            
            GameObject fire = Instantiate(fireBall, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * 10f;
            Destroy(fire, 2f);
        }
    }
    public void GrowFire()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        fireRenderer.enabled = true;
        activeRenderer = fireRenderer;
        GameManager.Instance.AddScore(1000);
        StartCoroutine(ScaleAnimation());
    }
    public void Grow()
    {
        if(activeRenderer == bigRenderer)
        {
            SetRenderer("Fire");
            GrowFire();
        
        }else if(activeRenderer == fireRenderer)
        {
            StartCoroutine(ScaleAnimation());
            GameManager.Instance.AddScore(1000);
            SetRenderer("Fire");
            
        }
        else
        {
            fireRenderer.enabled = false;
            smallRenderer.enabled = false;
            bigRenderer.enabled = true;
            activeRenderer = bigRenderer;
            GameManager.Instance.AddScore(1000);
            capsuleCollider.size = new Vector2 (1f, 1.5f);
            capsuleCollider.offset = new Vector2 (0f, 0f);
            StartCoroutine(ScaleAnimation());
            SetRenderer("Big");
        }
    }
    private void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;
        fireRenderer.enabled = false;
        activeRenderer = smallRenderer;

        capsuleCollider.size = new Vector2 (1f, 1f);
        capsuleCollider.offset = new Vector2 (0f, 0f);
        StartCoroutine(ScaleAnimation());
        SetRenderer("Small");
    }
    private void Death(){
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        deathAnimation.enabled = true;
        GameManager.Instance.ResetLevel(3f);
        SetRenderer("Small");
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
