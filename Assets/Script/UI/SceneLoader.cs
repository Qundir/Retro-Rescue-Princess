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
    }
    private void UpdateLivesTextLoader()
    {
        livesTextLoader.text = " :  " + GameManager.Instance.lives.ToString();
    }
    private void UpdateWorldTextLoader()
    {
        worldTextLoader.text = " WORLD : " + GameManager.Instance.world.ToString() + " - "+  GameManager.Instance.stage.ToString();
    }

        // Paneli belirli bir süre aktif hale getirir ve ardından devre dışı bırakır
    public void ActivateSceneLoaderPanel(float duration)
    {
        StartCoroutine(ActivatePanelCoroutine(duration));
    }

    private IEnumerator ActivatePanelCoroutine(float duration)
    {
        // Oyun zaman ölçeğini kaydet ve sonra duraklat
        float previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        // Paneli aktif hale getir
        sceneLoaderPanel.SetActive(true);

        // Belirtilen süre boyunca bekle
        yield return new WaitForSecondsRealtime(duration);

        // Paneli devre dışı bırak
        sceneLoaderPanel.SetActive(false);

        // Oyun zaman ölçeğini geri yükle
        Time.timeScale = previousTimeScale;
    }
}
