using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Text coinsText, livesText,stageText,timeText,scoreText;// can add more with , 
    private float remainingTime = 180f;
    public GameObject startPanel;
    public void FixedUpdate() // use fixed update for uı be updated
    {
        UpdateCoinText();
        UpdateLivesText();
        UpdateStageText();
        UpdateTimeText();
        UpdateScoreText();
    }
    private void UpdateCoinText()
    {
        coinsText.text = "COINS : " + GameManager.Instance.coins.ToString();
    }
    private void UpdateLivesText()
    {
        livesText.text = "LIVES : " + GameManager.Instance.lives.ToString();
    }
    private void UpdateStageText()
    {
        stageText.text = GameManager.Instance.world.ToString() + " - "+  GameManager.Instance.stage.ToString();
    }
    private void UpdateTimeText()
    {
        // update remaining time
        remainingTime -= Time.deltaTime;

        // update remaining time on text object
        timeText.text = "TIME : " + Mathf.CeilToInt(remainingTime).ToString();
        

        // chechk if the time is over 
        if (remainingTime <= 0f)
        {
            //ToDo
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = GameManager.Instance.score.ToString("000000");
    }

    public void StartGame()
    {
        //GameManager.Instance.ChangeTimeScale(1f);

    }
}
