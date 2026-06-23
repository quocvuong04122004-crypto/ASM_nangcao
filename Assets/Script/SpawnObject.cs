using UnityEngine;

[System.Serializable]
public class SpawnObject
{
    public GameObject prefab;

    [Range(0, 100)]
    public float spawnChance = 100;

    public int minAmount = 1;
    public int maxAmount = 1;

    public Vector2 randomScale = new Vector2(1f, 1f);
}