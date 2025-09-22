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
	
    public void LoadNextLevel()
    {
        GameManager.Instance.currentLevel++;

        switch (GameManager.Instance.currentLevel)
        {
            case 2:
                GameManager.Instance.levelTime = 90f;
                GameManager.Instance.objectSpeed = 14f;
                GameManager.Instance.spawnInterval = 0.7f;
                break;
            case 3:
                GameManager.Instance.levelTime = 120f;
                GameManager.Instance.objectSpeed = 10f;
                GameManager.Instance.spawnInterval = 0.5f;
                break;
            default:
                GameManager.Instance.levelTime = 60f;
                GameManager.Instance.objectSpeed = 12f;
                GameManager.Instance.spawnInterval = 0.4f;
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

