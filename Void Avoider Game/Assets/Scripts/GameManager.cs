using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float levelTime = 60f;
    public float objectSpeed = 5f;
    public float spawnInterval = 1f; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

