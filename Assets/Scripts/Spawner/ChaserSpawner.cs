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
