using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{	
	public Image spriteRenderer;
	public Sprite bg1; //default bg
	public Sprite bg2; //bg for level 2
	public Sprite bg3; //bg for level 3
	private Sprite newBG;
	
	void Start()
    {
        switch (GameManager.Instance.currentLevel)
        {
            case 2:
                spriteRenderer.sprite = bg2;
                break;
            case 3:
                spriteRenderer.sprite = bg3;
                break;
            default:
                spriteRenderer.sprite = bg1;
                break;
        }
    }
	
    public void LoadEndlessLevel()
    {
        GameManager.Instance.currentLevel = 4; // endless mode
        GameManager.Instance.endlessMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        GameManager.Instance.currentLevel++;

        switch (GameManager.Instance.currentLevel)
        {
            case 2:
                GameManager.Instance.levelTime = 9f;
                GameManager.Instance.objectSpeed = 12f;
                GameManager.Instance.spawnInterval = 0.5f;
                GameManager.Instance.endlessMode = false;
                break;
            case 3:
                GameManager.Instance.levelTime = 12f;
                GameManager.Instance.objectSpeed = 14f;
                GameManager.Instance.spawnInterval = 0.4f;
                GameManager.Instance.endlessMode = false;
                break;
            case 4:
                GameManager.Instance.objectSpeed = 16f;
                GameManager.Instance.spawnInterval = 0.3f;
                GameManager.Instance.endlessMode = true;
                break;
            default:
                GameManager.Instance.levelTime = 6f;
                GameManager.Instance.objectSpeed = 10f;
                GameManager.Instance.spawnInterval = 0.5f;
                GameManager.Instance.endlessMode = false;
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

