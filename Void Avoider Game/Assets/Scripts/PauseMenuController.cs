using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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
		timer.pause();
	}
	
	public void unpauseGame()
	{
		pauseMenuCanvas.SetActive(false);
		Time.timeScale = 1f;
		timer.unpause();
	}
	
	public void exitGame()
	{
		Application.Quit();
	}
}
