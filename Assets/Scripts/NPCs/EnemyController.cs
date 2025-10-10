using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject ship;
    protected Vector3 centerPoint;
    protected Vector3 spawnPos;
    protected Vector3 shipPosition;
    protected float enemySpeed = 18f;

    protected bool hasShipPos = false;
    protected bool isAtCenterPoint = false;
    protected bool projectileTriggerIsRunning = true;
    protected bool asteroidTriggerIsRunning = true;
    protected bool deathPlaneTriggerIsRunning = true;
    protected bool projectilePiercingTriggerIsRunning = true;
    
    
    protected void Flee()
    {
        transform.Translate(0f, 0.2f, 0);
    }

    // THESE ARE USED FOR DEBUGGING
    protected void Identify()
    {
        Debug.Log("I'm a child called " + gameObject);
    }

    protected void setShipPosition()
    {
        if (!ship.IsDestroyed())
        {
            Debug.Log("Setting Position...");
            ship = FindFirstObjectByType<ShipController>().gameObject;
            shipPosition = ship.transform.position;
        }
    }

}
