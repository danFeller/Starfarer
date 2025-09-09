using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    protected const float distanceToCameraEdgeX = 70f; // units from camera origin to it's edge on the x axis
    protected const float distanceToCameraEdgeY = 40f; // units from camera origin to it's edge on the y axis
    protected List<LevelSO> levels;

    [SerializeField] protected GameObject ship;
    [SerializeField] protected Slider slider;

    [Header("General Spawn Parameters")]
    [SerializeField] protected float distanceFromCameraEdge = 40f; // This is the offset for the y position of the spawn plane
    [SerializeField] protected float spawnTime = 0.1f;

    void Awake()
    {
        levels = FindFirstObjectByType<GameManager>().GetLevels();
    }


    protected void SpawnEnemy(GameObject enemy, float spawnChanceTop, float spawnChanceRight, float spawnChanceBottom, float spawnChanceLeft, float maxAmountToSpawn)
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
                    }
                }
                break;
        }
    }




    // Utility Functions for controlling the number of each enemy
    protected bool isEnemySpawnHappening(float cancelChance)
    {
        float a = Random.Range(0f, 100f);
        if (a < cancelChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool isTimeUp()
    {
        if (slider.value == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    // THESE ARE USED FOR DEBUGGING
    protected void Identify()
    {
        Debug.Log("I'm a child called " + gameObject);
    }

    protected void DebugDrawNewBox(float x, float y)
    {
        Debug.DrawLine(new Vector3(-x, y, 0), new Vector3(x, y, 0));
        Debug.DrawLine(new Vector3(x, y, 0), new Vector3(x, -y, 0));
        Debug.DrawLine(new Vector3(x, -y, 0), new Vector3(-x, -y, 0));
        Debug.DrawLine(new Vector3(-x, -y, 0), new Vector3(-x, y, 0));
    }

}
