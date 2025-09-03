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
