using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdiesSpawnerStopper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BirdiesSpawner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SpawnerStopper();
        }
    }
    private void SpawnerStopper()
    {
        BirdiesSpawner.SetActive(false);
    }

}
