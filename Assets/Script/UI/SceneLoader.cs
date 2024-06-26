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

    // Activate scene loader panel for while and deactiveted after 3sc
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
        Time.timeScale = 0f;

        
        sceneLoaderPanel.SetActive(true);

        // wait for that time
        yield return new WaitForSecondsRealtime(duration);


        sceneLoaderPanel.SetActive(false);

        // resume game
        Time.timeScale = 1f;

        panelActive = false;
    }
}
