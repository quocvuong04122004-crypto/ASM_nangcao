using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Spawn Objects")]
    public SpawnObject[] spawnObjects;

    [Header("Chunk Settings")]
    public float chunkSize = 50f;
    public int renderDistance = 3;

    private Dictionary<Vector2, GameObject> activeChunks =
        new Dictionary<Vector2, GameObject>();

    private Vector2 currentChunkPosition;

    private void Start()
    {
        currentChunkPosition = new Vector2(
            Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.z / chunkSize)
        );

        UpdateMapChunks();
    }

    private void Update()
    {
        Vector2 newChunkPosition = new Vector2(
            Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.z / chunkSize)
        );

        if (newChunkPosition != currentChunkPosition)
        {
            currentChunkPosition = newChunkPosition;
            UpdateMapChunks();
        }
    }

    private void UpdateMapChunks()
    {
        // Spawn chunk mới
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int z = -renderDistance; z <= renderDistance; z++)
            {
                Vector2 chunkPosition = new Vector2(
                    currentChunkPosition.x + x,
                    currentChunkPosition.y + z
                );

                if (!activeChunks.ContainsKey(chunkPosition))
                {
                    SpawnChunk(chunkPosition);
                }
            }
        }

        // Xóa chunk quá xa
        List<Vector2> chunksToRemove = new List<Vector2>();

        foreach (var chunk in activeChunks)
        {
            float distance = Vector2.Distance(
                chunk.Key,
                currentChunkPosition
            );

            if (distance > renderDistance)
            {
                chunksToRemove.Add(chunk.Key);
            }
        }

        foreach (Vector2 chunkPosition in chunksToRemove)
        {
            Destroy(activeChunks[chunkPosition]);
            activeChunks.Remove(chunkPosition);
        }
    }

    private void SpawnChunk(Vector2 chunkPosition)
    {
        if (spawnObjects.Length == 0)
            return;

        // Chọn prefab ngẫu nhiên
        SpawnObject data =
            spawnObjects[Random.Range(0, spawnObjects.Length)];

        if (data.prefab == null)
            return;

        // Tính vị trí chunk
        Vector3 position = new Vector3(
            chunkPosition.x * chunkSize,
            0f,
            chunkPosition.y * chunkSize
        );

        // Lấy độ cao terrain
        if (Terrain.activeTerrain != null)
        {
            float terrainHeight =
                Terrain.activeTerrain.SampleHeight(position);

            position.y = terrainHeight + Terrain.activeTerrain.transform.position.y;
        }

        // Spawn object
        GameObject newChunk = Instantiate(
            data.prefab,
            position,
            Quaternion.identity
        );

        activeChunks.Add(chunkPosition, newChunk);
    }
}