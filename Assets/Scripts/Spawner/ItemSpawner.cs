using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [SerializeField] List<GameObject> pickups = new List<GameObject>();

    [Header("Item Spawn Configuration")]
    [SerializeField] int itemMaxCount;
    [SerializeField] float itemSpawnChanceTop;
    [SerializeField] float itemSpawnChanceRight;
    [SerializeField] float itemSpawnChanceBottom;
    [SerializeField] float itemSpawnChanceLeft;
    [SerializeField] float itemMaxAmountToSpawn;

    float itemSpawnIncrement; //this value increases until it is greater than the spawnTime; this is a condition for spawning the respective enemy.
    int selectedItem;

    void Start()
    {
        pickups[selectedItem].GetComponent<WeaponPickUp>().resetCount();
    }

    void Update()
    {
        if (levels.Count > 0)
        {
            ConfigureSpawning();
        }
        if (!ship.IsDestroyed())
        {
            selectedItem = Random.Range(0, pickups.Count);

            if (itemSpawnIncrement > spawnTime && pickups[selectedItem].GetComponent<WeaponPickUp>().getCount() < itemMaxCount && slider.value != 0)
            {
                SpawnEnemy(pickups[selectedItem], itemSpawnChanceTop, itemSpawnChanceRight, itemSpawnChanceBottom, itemSpawnChanceLeft, itemMaxAmountToSpawn);
                itemSpawnIncrement = 0f;
            }
        }
        itemSpawnIncrement += Time.deltaTime;
        DebugDrawNewBox(distanceToCameraEdgeX + distanceFromCameraEdge, distanceToCameraEdgeY + distanceFromCameraEdge);
    }


    void ConfigureSpawning()
    {
        itemMaxCount = levels[0].itemMaxCount;
        itemSpawnChanceTop = levels[0].itemSpawnChanceTop;
        itemSpawnChanceRight = levels[0].itemSpawnChanceRight;
        itemSpawnChanceBottom = levels[0].itemSpawnChanceBottom;
        itemSpawnChanceLeft = levels[0].itemSpawnChanceLeft;
        itemMaxAmountToSpawn = levels[0].itemMaxAmountToSpawn;
    } 
}
