using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float levelTime = 60f;
    public float countdown = 3f;

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        timeRemaining = levelTime;
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                DisplayTime(timeRemaining);
                Debug.Log("Out of time!");
            }
        }
    }

    System.Collections.IEnumerator StartCountdown()
    {
        float count = countdown;
        while (count > 0)
        {
            timerText.text = "Starting in " + Mathf.Ceil(count).ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }
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

