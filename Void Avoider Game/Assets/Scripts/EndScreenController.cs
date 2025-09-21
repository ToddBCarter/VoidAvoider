using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private GameObject lossPanel;
    [SerializeField] private Button retryButton;

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
                break;
            default:
                endScreenDefault.SetActive(true);
                break;
        }
    }

    public void ShowLoss()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

