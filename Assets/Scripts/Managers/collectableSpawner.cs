using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableSpawner : MonoBehaviour
{
    #region Collectable References
    [Header("Collectable Prefab References")]
    [HideInInspector] private GameObject colA;
    [HideInInspector] private GameObject colB;
    [HideInInspector] private GameObject colC;
    #endregion

    [SerializeField] private GameObject[] spawnPool;

    #region Spawn System Variables
    [Header("Spawn System")]
    [SerializeField] private const int MAX_COLLECTABLE_NUM = 10;
    [SerializeField] private int currantCollectablesSpawned = 0;
    [SerializeField] private int spawnRate = 1;
    #endregion

    private void Start()
    {
        gameEvents.current.DecreaseSpawnCount += decreaseTotalSpawnCount;
    }


    void Update()
    {
        InvokeRepeating("SpawnCollectable", 3.0f, spawnRate);
    }


    private void SpawnCollectable()
    {
        if (currantCollectablesSpawned < MAX_COLLECTABLE_NUM)
        {
            int collectableNum = Random.Range(0, spawnPool.Length);
            int randX = Random.Range(-10, 10);
            int randY = Random.Range(-10, 10);

            Vector3 spawnPos = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randY);

            GameObject.Instantiate(spawnPool[collectableNum], spawnPos, Quaternion.identity);

            currantCollectablesSpawned++;
        }
        else
        {
            return;
        }

    }

    public void decreaseTotalSpawnCount()
    {
        currantCollectablesSpawned--;
    }
}
