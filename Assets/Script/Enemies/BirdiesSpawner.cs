using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    public GameObject birdiePrefab; // Birdie prefab'ını tutacak değişken
    private GameObject player;

    private void Start()
    {
        // Player'ı tag'e göre bul
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Sadece Player'ın x eksenindeki pozisyonunu al
            Vector3 playerPosition = player.transform.position;
            Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

            // Bu nesnenin pozisyonunu güncelle
            transform.position = newPosition;

            // 4 saniye bekle ve sonra Birdie çağıran fonksiyonu başlat
            StartCoroutine(StartCallingBirdiesAfterDelay(4f));
        }
        else
        {
            Debug.LogError("Player not found. Make sure the Player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Sadece Player'ın x eksenindeki pozisyonunu takip et
            Vector3 playerPosition = player.transform.position;
            Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }

    private IEnumerator StartCallingBirdiesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Belirtilen süre kadar bekle
        StartCoroutine(CallBirdieRepeatedly()); // Birdie çağıran coroutine'i başlat
    }

    private IEnumerator CallBirdieRepeatedly()
    {
        while (true)
        {
            // Rastgele bir sayı seç (1 ile 4 arasında)
            int birdieCount = Random.Range(1, 5);

            // Rastgele sayıda Birdie çağır
            for (int i = 0; i < birdieCount; i++)
            {
                InstantiateBirdie();
                yield return new WaitForSeconds(0.5f); // 0.5 saniye bekle
            }

            yield return new WaitForSeconds(0.75f); // 0.75 saniye bekle

            // Aynı işlemi tekrarla
        }
    }

    private void InstantiateBirdie()
    {
        if (birdiePrefab != null)
        {
            // Birdie prefab'ını instantiate et
            Instantiate(birdiePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Birdie prefab is not assigned.");
        }
    }
}
