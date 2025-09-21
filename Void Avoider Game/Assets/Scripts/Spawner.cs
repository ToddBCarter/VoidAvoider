using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnableObject[] objectsToSpawn;
    [SerializeField] private float spawnYRange = 4.5f;

    private readonly List<GameObject> highFrequency = new();
    private readonly List<GameObject> mediumFrequency = new();
    private readonly List<GameObject> lowFrequency = new();

    private float timer;

    void Start()
    {
        spawnYRange = Camera.main.orthographicSize;
        float objectSpeed = GameManager.Instance.objectSpeed;
        float spawnInterval = GameManager.Instance.spawnInterval;

        foreach (var obj in objectsToSpawn)
        {
            switch (obj.frequency)
            {
                case SpawnFrequency.High:
                    highFrequency.Add(obj.prefab);
                    break;
                case SpawnFrequency.Medium:
                    mediumFrequency.Add(obj.prefab);
                    break;
                case SpawnFrequency.Low:
                    lowFrequency.Add(obj.prefab);
                    break;
            }
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= GameManager.Instance.spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        int numberToSpawn = Random.Range(0, 4);
        for (int i = 0; i < numberToSpawn; i++)
        {
            int roll = Random.Range(1, 11);
            List<GameObject> chosenList;
            if (roll <= 6)
            {
                chosenList = highFrequency;
            }
            else if (roll <= 9)
            {
                chosenList = mediumFrequency;
            }
            else
            {
                chosenList = lowFrequency;
            }

            int index = Random.Range(0, chosenList.Count);

            Vector3 spawnPos = new(transform.position.x, Random.Range(-spawnYRange, spawnYRange), 0f);
            GameObject obj = Instantiate(chosenList[index], spawnPos, Quaternion.identity);

            obj.AddComponent<Mover>().Speed = GameManager.Instance.objectSpeed;
        }
    }
}
