using System.Collections;
using UnityEngine;

public class BirdieMovement : MonoBehaviour
{
    public float radius = 5f; // Yarıçap
    private float height;
    public float speed = 2; // Hareket hızı
    private float angle = -Mathf.PI; // Başlangıç açısı (soldan sağa başlamak için -π)
    private bool isMoving = true;
    private Vector3 startPosition;

    private void Start()
    {
        // Başlangıç pozisyonunu kaydet
        startPosition = transform.position;

        // Yüksekliği rastgele seç
        height = Random.Range(-20f, -15f);

        // X pozisyonunda rastgele bir ofset belirle (3 ile 8 birim arasında)
        float randomXOffset = Random.Range(3f, 8f);

        // Ofseti başlangıç pozisyonuna ekle
        startPosition.x += randomXOffset;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Açıyı güncelle
            angle += speed * Time.deltaTime;

            // Yarım daire hareketi
            float x = radius * Mathf.Cos(angle);
            float y = height * Mathf.Sin(angle) / 2;

            // Pozisyonu güncelle (başlangıç pozisyonuna göre)
            transform.position = startPosition + new Vector3(x, y, 0);

            // Açının 0 ile π arasında olmasını sağla (Yarım daire)
            if (angle > 0)
            {
                isMoving = false; // Hareketi durdur
                Destroy(gameObject); // Oyun nesnesini yok et
            }
        }
    }
}
