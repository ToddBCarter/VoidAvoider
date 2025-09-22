using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private GameObject lossPanel;
    [SerializeField] private Button retryButton;
    [SerializeField] private TextMeshProUGUI lossText;

    public GameObject endScreenDefault;
    public GameObject finalEndScreen;

    private void Start()
    {
        lossPanel.SetActive(false);
        retryButton.onClick.AddListener(ReloadLevel);
    }

    public void ShowVictory()
    {
        int level = GameManager.Instance.currentLevel;

        endScreenDefault.SetActive(false);
        finalEndScreen.SetActive(false);

        switch (level)
        {
            case 3:
                finalEndScreen.SetActive(true);
                Time.timeScale = 0f;
                break;
            default:
                endScreenDefault.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }

    public void ShowLoss(string message = null)
    {
        lossPanel.SetActive(true);
        if (GameManager.Instance.endlessMode = true)
        {
            lossText.text = message;
        }
        else
        {
            lossText.text = "YOU HAVE BEEN SPAGHETTIFIED";
        }
        AudioManager.Instance.ChangeBackgroundMusic(AudioManager.Instance.MenuMusic, 0.4f, true);
        Time.timeScale = 0f;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}