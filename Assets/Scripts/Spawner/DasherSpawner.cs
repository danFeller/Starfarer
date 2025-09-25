using Unity.VisualScripting;
using UnityEngine;

public class DasherSpawner : Spawner
{
    [SerializeField] GameObject dasherEnemy;
    [Header("Dasher Spawn Configuration")]
    [SerializeField] int dasherMaxCount;
    [SerializeField] float dasherSpawnChanceTop;
    [SerializeField] float dasherSpawnChanceRight;
    [SerializeField] float dasherSpawnChanceBottom;
    [SerializeField] float dasherSpawnChanceLeft;
    [SerializeField] float dasherMaxAmountToSpawn;

    float dasherSpawnIncrement; //this value increases until it is greater than the spawnTime; this is a condition for spawning the respective enemy.

    void Start()
    {
        dasherEnemy.GetComponent<DasherController>().resetCount();
    }

    void Update()
    {
        if (levels.Count > 0)
        {
            ConfigureSpawning();
        }
        if (!ship.IsDestroyed())
        {
            if (dasherSpawnIncrement > spawnTime && dasherEnemy.GetComponent<DasherController>().getCount() < dasherMaxCount && slider.value != 0)
            {
                SpawnEnemy(dasherEnemy, dasherSpawnChanceTop, dasherSpawnChanceRight, dasherSpawnChanceBottom, dasherSpawnChanceLeft, dasherMaxAmountToSpawn);
                dasherSpawnIncrement = 0f;
            }
        }
        dasherSpawnIncrement += Time.deltaTime;
        DebugDrawNewBox(distanceToCameraEdgeX + distanceFromCameraEdge, distanceToCameraEdgeY + distanceFromCameraEdge);
    }


    void ConfigureSpawning()
    {
        dasherMaxCount = levels[0].dasherMaxCount;
        dasherSpawnChanceTop = levels[0].dasherSpawnChanceTop;
        dasherSpawnChanceRight = levels[0].dasherSpawnChanceRight;
        dasherSpawnChanceBottom = levels[0].dasherSpawnChanceBottom;
        dasherSpawnChanceLeft = levels[0].dasherSpawnChanceLeft;
        dasherMaxAmountToSpawn = levels[0].dasherMaxAmountToSpawn;
    } 
}
