using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private Button resumeButton;
	[SerializeField] private Button exitButton;
	[SerializeField] private LevelTimer timer;
	
    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }


    void Update()
    {
        if (Keyboard.current[Key.P].isPressed)
		{
			pauseGame();
		}
    }
	
	public void pauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void unpauseGame()
    {
        pauseMenuCanvas.SetActive(false);
        if (timer.timerRunning)
        {
            Time.timeScale = 1f;
        }
    }
	
	public void exitGame()
	{
		Application.Quit();
	}
	
	public void loadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
