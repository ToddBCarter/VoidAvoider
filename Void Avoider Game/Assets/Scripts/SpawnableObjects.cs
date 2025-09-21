using UnityEngine;

public enum SpawnFrequency
{
    Low,
    Medium,
    High
}

[System.Serializable]
public class SpawnableObject
{
    public GameObject prefab;
    public SpawnFrequency frequency;
}