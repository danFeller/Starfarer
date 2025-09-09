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

