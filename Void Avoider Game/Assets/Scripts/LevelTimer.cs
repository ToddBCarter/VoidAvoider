using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float levelTime = 60f;
    public float countdown = 3f;
    public PlayerHealth playerHealth;
    public VictoryScreenController victoryScreenController;

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        Time.timeScale = 0f;
        timeRemaining = levelTime;
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.unscaledDeltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                DisplayTime(timeRemaining);
                if (playerHealth.CurrentHealth > 0)
                {
                    victoryScreenController.ShowVictory();
                }
                else
                {
                    Debug.Log("Player dead.");
                }
            }
        }
    }

    System.Collections.IEnumerator StartCountdown()
    {
        float count = countdown;
        while (count > 0)
        {
            timerText.text = "Starting in " + Mathf.Ceil(count).ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }
        Time.timeScale = 1f;
        timerRunning = true;
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

