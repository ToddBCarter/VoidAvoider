using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private GameObject lossPanel;
    [SerializeField] private Button retryButton;

    private void Start()
    {
        victoryPanel.SetActive(false);
        nextLevelButton.onClick.AddListener(LoadNextLevel);

        lossPanel.SetActive(false);
        retryButton.onClick.AddListener(ReloadLevel);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowLoss()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Name");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
