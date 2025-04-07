using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] platforms;
    private Transform playerTransform;
    private int platformCount = 0;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }
    private void Update()
    {
        if (playerTransform.position.y < GetSpawnYPosition(platformCount))
        {
            SpawnTile();
        }
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex >= 0 && prefabIndex < platforms.Length)
        {
            go = Instantiate(platforms[prefabIndex]);
        }
        else
        {
            go = Instantiate(platforms[Random.Range(0, platforms.Length)]); 
        }
        go.transform.position = new Vector3(4.5f, GetSpawnYPosition(platformCount), 0);
        platformCount++; 
    }
    private float GetSpawnYPosition(int count)
    {
        return -31 * (count + 1) - 2;
    }
}