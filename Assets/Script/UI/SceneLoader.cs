using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public GameObject sceneLoaderPanel;
    public Text livesTextLoader, worldTextLoader;

    public void Start()
    {
        UpdateLivesTextLoader();
        UpdateWorldTextLoader();
        ActivateSceneLoaderPanel(3f);
    }

    private void UpdateLivesTextLoader()
    {
        livesTextLoader.text = " :  " + GameManager.Instance.lives.ToString();
    }

    private void UpdateWorldTextLoader()
    {
        worldTextLoader.text = " WORLD : " + GameManager.Instance.world.ToString() + " - " + GameManager.Instance.stage.ToString();
    }

    // Paneli belirli bir süre aktif hale getirir ve ardından devre dışı bırakır 
    private bool panelActive = false;

    public void ActivateSceneLoaderPanel(float duration)
    {
        if (!panelActive)
        {
            StartCoroutine(ActivatePanelCoroutine(duration));
        }
    }

    private IEnumerator ActivatePanelCoroutine(float duration)
    {
        panelActive = true;

        // save game previous time scale and pause game
        float previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        
        sceneLoaderPanel.SetActive(true);

        // wait for that time
        yield return new WaitForSecondsRealtime(duration);


        sceneLoaderPanel.SetActive(false);

        // resume game
        Time.timeScale = previousTimeScale;

        panelActive = false;
    }
}
