using UnityEngine;

public class RevivePanel : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.Instance.LoadLevel(1,0);
        GameManager.Instance.NewGame();
    }
    public void AddLifeAdd()
    {
        GameManager.Instance.AddLife();
        GameManager.Instance.AddlifeAddLevelLoader();
        GameManager.Instance.FindRevivePanel();
    }
}
