using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    public static float timer;
    static float highScore;
    [SerializeField] Text timerText, highScoreText;
    [SerializeField] float smallScale, bigScale;
    [SerializeField] GameObject GameOverPanel;

    void Start()
    {
        GameOverPanel.SetActive(false);
        timer = 0;
        // Debug.Log(highScore);
        UpdateHighScoreText();
    }

    void Update()
    {
        if (!GameManager.isPlayerDead)
        {
            timer += Time.deltaTime;

            timerText.text = timer.ToString("F3").Replace(',',':');  //this "F3" means "with three numbers after the floating point" apparently

            // Complicated thing to say "when the timer is an integer, have the big scale, then shrink until the timer is at .99999
            float scaleForTime = smallScale + ((bigScale - smallScale) * (1 - (timer - (int)timer))); 
            timerText.rectTransform.localScale = new Vector3(scaleForTime, scaleForTime, 1);
        }
    }

    public void StopTimer() // AKA "Player Dead"
    {
        if (timer > highScore)
        {
            highScore = timer;
            UpdateHighScoreText();
        }
        GameOverPanel.SetActive(true);

    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "HIGH SCORE: " + highScore.ToString("F3").Replace(',',':');
    }
}
