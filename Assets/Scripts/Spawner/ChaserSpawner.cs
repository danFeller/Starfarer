using Unity.VisualScripting;
using UnityEngine;

public class ChaserSpawner : Spawner
{
    [SerializeField] GameObject chaserEnemy;
    [Header("Chaser Spawn Configuration")]
    [SerializeField] int chaserMaxCount;
    [SerializeField] float chaserSpawnChanceTop;
    [SerializeField] float chaserSpawnChanceRight;
    [SerializeField] float chaserSpawnChanceBottom;
    [SerializeField] float chaserSpawnChanceLeft;
    [SerializeField] float chaserMaxAmountToSpawn;

    float chaserSpawnIncrement; //this value increases until it is greater than the spawnTime; this is a condition for spawning the respective enemy.

    void Start()
    {
        chaserEnemy.GetComponent<ChaserController>().resetCount();
    }

    void Update()
    {
        if (levels.Count > 0)
        {
            ConfigureSpawning();
        }
        if (!ship.IsDestroyed())
        {
            if (chaserSpawnIncrement > spawnTime && chaserEnemy.GetComponent<ChaserController>().getCount() < chaserMaxCount && slider.value != 0)
            {
                SpawnEnemy(chaserEnemy, chaserSpawnChanceTop, chaserSpawnChanceRight, chaserSpawnChanceBottom, chaserSpawnChanceLeft, chaserMaxAmountToSpawn);
                chaserSpawnIncrement = 0f;
            }
        }
        chaserSpawnIncrement += Time.deltaTime;
        DebugDrawNewBox(distanceToCameraEdgeX + distanceFromCameraEdge, distanceToCameraEdgeY + distanceFromCameraEdge);
    }

    void SpawnEnemy(GameObject enemy, float spawnChanceTop, float spawnChanceRight, float spawnChanceBottom, float spawnChanceLeft, float maxAmountToSpawn)
    {
        float spawnLineX, spawnX, spawnLineY, spawnY;
        Vector3 spawnPos;
        int sideSelection = Random.Range(1, 5);
        switch (sideSelection)
        {
            case 1:
                if (isEnemySpawnHappening(spawnChanceTop))
                {
                    spawnLineX = distanceFromCameraEdge + distanceToCameraEdgeX;
                    spawnX = Random.Range(-spawnLineX, spawnLineX);
                    spawnPos = new Vector3(spawnX, distanceFromCameraEdge + distanceToCameraEdgeY, 0);
                    int spawnCount = (int)Random.Range(1f, maxAmountToSpawn);
                    for (int i = 0; i < spawnCount; i++)
                    {
                        Instantiate(enemy, spawnPos, Quaternion.identity).SetActive(true); // Spawn enemy anywhere on the X Axis along Y level 50.
                        chaserEnemy.GetComponent<ChaserController>().incrementCounter();
                    }
                }
                break;
            case 2:
                if (isEnemySpawnHappening(spawnChanceRight))
                {
                    spawnLineY = distanceFromCameraEdge + distanceToCameraEdgeY;
                    spawnY = Random.Range(-spawnLineY, spawnLineY);
                    spawnPos = new Vector3(distanceFromCameraEdge + distanceToCameraEdgeX, spawnY, 0);
                    int spawnCount = (int)Random.Range(1f, maxAmountToSpawn);
                    for (int i = 0; i < spawnCount; i++)
                    {
                        Instantiate(enemy, spawnPos, Quaternion.identity).SetActive(true); // Spawn enemy anywhere on the X Axis along Y level 50.
                        chaserEnemy.GetComponent<ChaserController>().incrementCounter();
                    }
                }
                break;
            case 3:
                if (isEnemySpawnHappening(spawnChanceBottom))
                {
                    spawnLineX = distanceFromCameraEdge + distanceToCameraEdgeX;
                    spawnX = Random.Range(-spawnLineX, spawnLineX);
                    spawnPos = new Vector3(spawnX, -(distanceFromCameraEdge + distanceToCameraEdgeY), 0);
                    int spawnCount = (int)Random.Range(1f, maxAmountToSpawn);
                    for (int i = 0; i < spawnCount; i++)
                    {
                        Instantiate(enemy, spawnPos, Quaternion.identity).SetActive(true); // Spawn enemy anywhere on the X Axis along Y level 50.
                        chaserEnemy.GetComponent<ChaserController>().incrementCounter();
                    }
                }
                break;
            case 4:
                if (isEnemySpawnHappening(spawnChanceLeft))
                {
                    spawnLineY = distanceFromCameraEdge + distanceToCameraEdgeY;
                    spawnY = Random.Range(-spawnLineY, spawnLineY);
                    spawnPos = new Vector3(-(distanceFromCameraEdge + distanceToCameraEdgeX), spawnY, 0);
                    int spawnCount = (int)Random.Range(1f, maxAmountToSpawn);
                    for (int i = 0; i < spawnCount; i++)
                    {
                        Instantiate(enemy, spawnPos, Quaternion.identity).SetActive(true); // Spawn enemy anywhere on the X Axis along Y level 50.
                        chaserEnemy.GetComponent<ChaserController>().incrementCounter();
                    }
                }
                break;
        }
    }

    void ConfigureSpawning()
    {
        chaserMaxCount = levels[0].chaserMaxCount;
        chaserSpawnChanceTop = levels[0].chaserSpawnChanceTop;
        chaserSpawnChanceRight = levels[0].chaserSpawnChanceRight;
        chaserSpawnChanceBottom = levels[0].chaserSpawnChanceBottom;
        chaserSpawnChanceLeft = levels[0].chaserSpawnChanceLeft;
        chaserMaxAmountToSpawn = levels[0].chaserMaxAmountToSpawn;
    } 



}
