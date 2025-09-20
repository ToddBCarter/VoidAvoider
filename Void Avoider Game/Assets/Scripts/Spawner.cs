using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private float spawnInterval = 1f;
    public float spawnYRange = 4.5f;
    [SerializeField] private float objectSpeed = 5f;

    private float timer;

    void Start()
    {
        spawnYRange = Camera.main.orthographicSize;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        int index = Random.Range(0, objectsToSpawn.Length);

        float halfHeight = Camera.main.orthographicSize;

        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(-spawnYRange, spawnYRange), 0f);
        GameObject obj = Instantiate(objectsToSpawn[index], spawnPos, Quaternion.identity);

        obj.AddComponent<Mover>().Speed = objectSpeed;
    }
}
