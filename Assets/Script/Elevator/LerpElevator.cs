using UnityEngine;

public class LerpElevator : MonoBehaviour
{
    public float initialDelay; // Başlangıç gecikme süresi
    public float moveTime; // Lerp işlemi süresi
    public Vector3 startPos; // Başlangıç pozisyonu
    public Vector3 endPos; // Bitiş pozisyonu
    private float timer = 0f; // Zamanlayıcı
    private bool movingToEnd = true; // Hareket yönü kontrolü

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
