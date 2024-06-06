using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject StartPanel, SettingsPanel,LevelSelector; // settings and credit should get update 

    public void StartTheGame()
    {
        GameManager.Instance.StartLoaderGame(1,1);
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
    public void OpenLevelSelector()
    {
        LevelSelector.SetActive(true);
        StartPanel.SetActive(false);
    }
    public void CloseLevelSelector()
    {
        LevelSelector.SetActive(false);
        StartPanel.SetActive(true);
    }
    public void StartLevel1_1()
    {
        GameManager.Instance.StartLoaderGame(1,1);
    }
    public void StartLevel1_2(){
        GameManager.Instance.StartLoaderGame(1,2);
    }
    public void StartLevel1_3(){
        GameManager.Instance.StartLoaderGame(1,3);
    }
    public void StartLevel1_4()
    {
        GameManager.Instance.StartLoaderGame(1,4);
    }
    public void StartLevel2_1()
    {
        GameManager.Instance.StartLoaderGame(2,1);
    }
    public void StartLevel2_2()
    {
        GameManager.Instance.StartLoaderGame(2,2);
    }
    public void StartLevel2_3()
    {
        GameManager.Instance.StartLoaderGame(2,3);
    }

}
