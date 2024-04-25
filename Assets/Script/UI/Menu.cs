using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject StartPanel, SettingsPanel,CreditPanel; // settings and credit should get update 
    public void Start()
    {
        Time.timeScale = 0f;
    }
    public void StartTheGame()
    {
        Time.timeScale = 1f;
        StartPanel.SetActive(false);
    }
}
