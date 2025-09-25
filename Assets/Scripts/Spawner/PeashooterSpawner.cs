using Unity.VisualScripting;
using UnityEngine;

public class PeashooterSpawner : Spawner
{
    [SerializeField] GameObject peaShooterEnemy;
    [Header("Peashooter Spawn Configuration")]
    [SerializeField] int peaShooterMaxCount;
    [SerializeField] float peaShooterSpawnChanceTop;
    [SerializeField] float peaShooterSpawnChanceRight;
    [SerializeField] float peaShooterSpawnChanceBottom;
    [SerializeField] float peaShooterSpawnChanceLeft;
    [SerializeField] float peaShooterMaxAmountToSpawn;

    float peaShooterSpawnIncrement; //this value increases until it is greater than the spawnTime; this is a condition for spawning the respective enemy.

    void Start()
    {
        peaShooterEnemy.GetComponent<PeashooterController>().resetCount();
    }

    void Update()
    {
        if (levels.Count > 0)
        {
            ConfigureSpawning();
        }
        if (!ship.IsDestroyed())
        {
            if (peaShooterSpawnIncrement > spawnTime && peaShooterEnemy.GetComponent<PeashooterController>().getCount() < peaShooterMaxCount && slider.value != 0)
            {
                SpawnEnemy(peaShooterEnemy, peaShooterSpawnChanceTop, peaShooterSpawnChanceRight, peaShooterSpawnChanceBottom, peaShooterSpawnChanceLeft, peaShooterMaxAmountToSpawn);
                peaShooterSpawnIncrement = 0f;
            }
        }
        peaShooterSpawnIncrement += Time.deltaTime;
        DebugDrawNewBox(distanceToCameraEdgeX + distanceFromCameraEdge, distanceToCameraEdgeY + distanceFromCameraEdge);
    }


    void ConfigureSpawning()
    {
        peaShooterMaxCount = levels[0].peaShooterMaxCount;
        peaShooterSpawnChanceTop = levels[0].peaShooterSpawnChanceTop;
        peaShooterSpawnChanceRight = levels[0].peaShooterSpawnChanceRight;
        peaShooterSpawnChanceBottom = levels[0].peaShooterSpawnChanceBottom;
        peaShooterSpawnChanceLeft = levels[0].peaShooterSpawnChanceLeft;
        peaShooterMaxAmountToSpawn = levels[0].peaShooterMaxAmountToSpawn;
    } 
}

