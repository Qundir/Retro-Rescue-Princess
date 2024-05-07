using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float initialDelay; // Başlangıç gecikme süresi
    public float moveTime; // Lerp işlemi süresi
    public Vector3 startPos; // Başlangıç pozisyonu
    public Vector3 endPos; // Bitiş pozisyonu
    private float timer = 0f; // Zamanlayıcı

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
            transform.position = Vector3.Lerp(startPos, endPos, t);

            // Lerp işlemi tamamlandıktan sonra timer'ı sıfırla
            if (t >= 1f)
            {
                timer = 0f;
            }
        }
    }
}
