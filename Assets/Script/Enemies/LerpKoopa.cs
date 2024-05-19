using UnityEngine;


public class LerpKoopa : MonoBehaviour
{
    public float initialDelay; // Başlangıç gecikme süresi
    public float moveTime; // Lerp işlemi süresi
    public Vector3 startPos; // Başlangıç pozisyonu
    public Vector3 endPos; // Bitiş pozisyonu
    private float timer = 0f; // Zamanlayıcı
    private bool movingToEnd = true; // Hareket yönü kontrolü
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enabled = false;
    }


    private void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Shell"))
            return;
        
        enabled = false;
    }
    private void OnEnable()
    {
        rb.WakeUp();
    }
    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.Sleep();
    }
    void Update()
    {
        // Başlangıç gecikme süresini kontrol et
        if (initialDelay > 0f)
        {
            initialDelay -= Time.deltaTime;
        }
        else
        {
            // Lerp işlemini başlat
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / moveTime);
            if (movingToEnd)
            {
                transform.position = Vector3.Lerp(startPos, endPos, t);
                if (t >= 1f)
                {
                    // Bitiş pozisyonuna ulaşıldığında hareket yönünü değiştir
                    timer = 0f;
                    movingToEnd = false;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(endPos, startPos, t);
                if (t >= 1f)
                {
                    // Başlangıç pozisyonuna ulaşıldığında hareket yönünü değiştir
                    timer = 0f;
                    movingToEnd = true;
                }
            }
        }
    }
}
