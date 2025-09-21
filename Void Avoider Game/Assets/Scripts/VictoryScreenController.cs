using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScreenController : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private Button nextLevelButton;

    private void Start()
    {
        victoryPanel.SetActive(false);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Name");
    }
}
