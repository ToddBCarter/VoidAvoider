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

    private float timer;
    public bool timerRunning = false;

    void Start()
    {
        Time.timeScale = 0f;
        if (GameManager.Instance.endlessMode)
        {
            timer = 0f;
        }
        else
        {
            timer = GameManager.Instance.levelTime; // normal countdown
        }

        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (timerRunning)
        {
            if (!GameManager.Instance.endlessMode)
            {
                if (timer > 0)
                {
                    //timeRemaining -= Time.unscaledDeltaTime;
                    timer -= Time.deltaTime;
                    DisplayTime(timer);
                }
                else
                {
                    timerRunning = false;
                    timer = 0;
                    DisplayTime(timer);
                    if (playerHealth.CurrentHealth > 0)
                    {
                        AudioManager.Instance.PlaySound("whoosh");
                        AudioManager.Instance.PlaySound("success");
                        AudioManager.Instance.ChangeBackgroundMusic(AudioManager.Instance.VictoryMusic, 0.4f, true);
                        endScreenController.ShowVictory();
                    }
                    else
                    {
                        endScreenController.ShowLoss();
                    }
                }
            }
            else
            {
                if (playerHealth.CurrentHealth > 0)
                {
                    timer += Time.deltaTime;
                    DisplayTime(timer);
                }
                else
                {
                    timerRunning = false;
                    string message = "Time survived: " + FormatTime(timer);
                endScreenController.ShowLoss(message);
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
        timerText.text = FormatTime(timeToDisplay);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
