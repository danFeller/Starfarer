using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    static int itemCount;
    Vector3 spawnPos;
    float itemSpeed = 30f;

    const float pathX = 18f;
    const float pathY = 18f;
    float guideX;
    float guideY;
    bool deathPlaneTriggerIsRunning = true;
    bool shipTriggerIsRunning = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spawnPos = transform.position;
        incrementCounter();
    }
    
    // Update is called once per frame
    void Update()
    {
        PathToDirection();
    }

    void PathToDirection()
    {
        guideX = Random.Range(-pathX, pathX);
        guideY = Random.Range(-pathY, pathY);
        float directionX = guideX - spawnPos.x;
        float directionY = guideY - spawnPos.y;

        Vector3 move = new Vector3(directionX, directionY, 0f).normalized * itemSpeed * Time.deltaTime;
        transform.Translate(move);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathPlane" && deathPlaneTriggerIsRunning)
        {
            deathPlaneTriggerIsRunning = false;
            decrementCounter();
            Destroy(gameObject);
        }
        if (other.tag == "Player" && shipTriggerIsRunning)
        {
            shipTriggerIsRunning = false;
            decrementCounter();
            Destroy(gameObject);
        }
    }

    public int getCount()
    {
        return itemCount;
    }
    public void incrementCounter()
    {
        itemCount++;
    }
    public void decrementCounter()
    {
        itemCount--;
    }
    public void resetCount()
    {
        itemCount = 0;
    }
}