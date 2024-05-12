using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.ResetLevel(3.0f);
            GameManager.Instance.StoreRendererType("Small");
        }else{
            Destroy(other.gameObject);
        }
    }
}
