using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadLevel2()
    {
        GameManager.Instance.levelTime = 90f;
        GameManager.Instance.objectSpeed = 8f;
        GameManager.Instance.spawnInterval = 0.7f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

