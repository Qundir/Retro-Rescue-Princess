using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject StartPanel, SettingsPanel,CreditPanel; // settings and credit should get update 
    public void StartTheGame()
    {
        GameManager.Instance.LoadLevel(1,1);
    }
    public void OpenSettingsPanel()
    {
        StartPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
        StartPanel.SetActive(true);
    }
    public void OpenCreditPanel()
    {
        CreditPanel.SetActive(true);
        StartPanel.SetActive(false);
    }
    public void CloseCreditPanel()
    {
        CreditPanel.SetActive(false);
        StartPanel.SetActive(true);
    }
}
