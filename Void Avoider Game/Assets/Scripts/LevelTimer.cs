using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float levelTime = 60f;
    public float countdown = 20f;
    public PlayerHealth playerHealth;
    public VictoryScreenController victoryScreenController;

    private float timeRemaining;
	private float countdownRemaining;
    private bool timerRunning = false;
	private bool countingDown = true;
	private bool paused = false;
	private int cdR = 0;

    void Start()
    {
        Time.timeScale = 0f;
        timeRemaining = levelTime;
		countdownRemaining = countdown;
        //StartCoroutine(StartCountdown());
		//Debug.Log("whatever" + countdown);
    }

    void Update()
    {
		if (countingDown)
		{
			float delta = Mathf.Min(Time.unscaledDeltaTime, 0.1f);
			countdownRemaining -= delta;
			//cdR = Mathf.FloorToInt(countdownRemaining / 360); //translate to seconds
			if (countdownRemaining > 0)
			{
				timerText.text = "Starting in " + Mathf.Ceil(countdownRemaining).ToString();
			}
			else
			{
				if(paused == false)
				{
					countingDown = false;
					Time.timeScale = 1f;
					timerRunning = true;
				}
			}
		}		
        else if (timerRunning)
        {
			//Debug.Log("test" + timerRunning);
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
            yield return new WaitForSeconds(1f);
            count--;
        }
		
		//StopCoroutine(StartCountdown());
        timerRunning = true;
		Time.timeScale = 1f;
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
	
	public void pause()
	{
		Time.timeScale = 0f;
		paused = true;
	}
	
	public void unpause()
	{
		Time.timeScale = 1f;
		paused = false;	
	}
}

