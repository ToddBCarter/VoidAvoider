using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdown = 3f;
    public PlayerHealth playerHealth;
    public EndScreenController endScreenController;
    [SerializeField] private GameObject pauseMenuCanvas;

    private float timeRemaining;
    public bool timerRunning = false;

    void Start()
    {
        Time.timeScale = 0f;
        timeRemaining = GameManager.Instance.levelTime;
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                //timeRemaining -= Time.unscaledDeltaTime;
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
                    AudioManager.Instance.PlaySound("whoosh");
                    AudioManager.Instance.PlaySound("success");
                    AudioManager.Instance.ChangeBackgroundMusic(AudioManager.Instance.VictoryMusic, 0.4f, true);
                    endScreenController.ShowVictory();
                }
                else
                {
                    Debug.Log("Player dead.");
                }
            }
        }
    }

public IEnumerator StartCountdown()
    {
        float count = countdown;
        while (true)
        {
            while (count > 0)
            {
                if (!pauseMenuCanvas.activeInHierarchy)
                {
                    timerText.text = "Starting in " + Mathf.Ceil(count).ToString();
                    yield return new WaitForSecondsRealtime(1f);
                    count--;
                }
                else
                {
                    yield return null;
                }
            }
            if (!pauseMenuCanvas.activeInHierarchy)
            {
                Time.timeScale = 1f;
                timerRunning = true;
                break;
            }
            else
            {
                count++;
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
