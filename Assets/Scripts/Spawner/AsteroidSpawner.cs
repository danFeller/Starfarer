using UnityEngine;
using Unity.VisualScripting;

public class AsteroidSpawner : Spawner
{
    [SerializeField] GameObject asteroidEnemy;
    [Header("Asteroid Spawn Configuration")]
    [SerializeField] int asteroidMaxCount;
    [SerializeField] float asteroidSpawnChanceTop;
    [SerializeField] float asteroidSpawnChanceRight;
    [SerializeField] float asteroidSpawnChanceBottom;
    [SerializeField] float asteroidSpawnChanceLeft;
    [SerializeField] float asteroidMaxAmountToSpawn;

    float asteroidSpawnIncrement;

    void Start()
    {
        asteroidEnemy.GetComponent<AsteroidController>().resetCount();
    }

    void Update()
    {
        if (levels.Count > 0)
        {
            ConfigureSpawning();
        }
        if (!ship.IsDestroyed())
        {
            if (asteroidSpawnIncrement > spawnTime && asteroidEnemy.GetComponent<AsteroidController>().getCount() < asteroidMaxCount && slider.value != 0)
            {
                SpawnEnemy(asteroidEnemy, asteroidSpawnChanceTop, asteroidSpawnChanceRight, asteroidSpawnChanceBottom, asteroidSpawnChanceLeft, asteroidMaxAmountToSpawn);
                asteroidSpawnIncrement = 0f;
            }
        }
        asteroidSpawnIncrement += Time.deltaTime;
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
                        asteroidEnemy.GetComponent<AsteroidController>().incrementCounter();
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
                        asteroidEnemy.GetComponent<AsteroidController>().incrementCounter();
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
                        asteroidEnemy.GetComponent<AsteroidController>().incrementCounter();
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
                        asteroidEnemy.GetComponent<AsteroidController>().incrementCounter();
                    }
                }
                break;
        }
    }
    
    void ConfigureSpawning()
    {
        asteroidMaxCount = levels[0].asteroidMaxCount;
        asteroidSpawnChanceTop = levels[0].asteroidSpawnChanceTop;
        asteroidSpawnChanceRight = levels[0].asteroidSpawnChanceRight;
        asteroidSpawnChanceBottom = levels[0].asteroidSpawnChanceBottom;
        asteroidSpawnChanceLeft = levels[0].asteroidSpawnChanceLeft;
        asteroidMaxAmountToSpawn = levels[0].asteroidMaxAmountToSpawn;
    }
}

