using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Text coinsText, livesText,stageText,timeText,scoreText;// reference to scene text 
    private float remainingTime = 180f;
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
        coinsText.text = "COINS : " + GameManager.Instance.coins.ToString();// update text on scene
    }
    private void UpdateLivesText()
    {
        livesText.text = "LIVES : " + GameManager.Instance.lives.ToString();// update text on scene
    }
    private void UpdateStageText()
    {
        stageText.text = GameManager.Instance.world.ToString() + " - "+  GameManager.Instance.stage.ToString(); // update text on scene
    }
    private void UpdateTimeText()
    {
        // update remaining time
        remainingTime -= Time.deltaTime;// update text on scene

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
}
