using UnityEngine;

public class AsteroidController : EnemyController
{
    static int asteroidCount;

    //determines the set of points the asteroid travels across
    const float pathX = 18f;
    const float pathY = 18f;


    float guideX;
    float guideY;

    void Awake()
    {
        incrementCounter();
    }


    void Start()
    {
        enemySpeed = 40f;
        guideX = Random.Range(-pathX, pathX);
        guideY = Random.Range(-pathY, pathY);
        spawnPos = transform.position;
    }

    void Update()
    {
        DebugDrawNewBox(pathX, pathY);
        PathToDirection();
    }

    void PathToDirection()
    {
        float directionX = guideX - spawnPos.x;
        float directionY = guideY - spawnPos.y;

        Vector3 move = new Vector3(directionX, directionY, 0f).normalized * enemySpeed * Time.deltaTime;
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
    }



    public int getCount()
    {
        return asteroidCount;
    }
    public void incrementCounter()
    {
        asteroidCount++;
    }
    public void decrementCounter()
    {
        asteroidCount--;
    }
    public void resetCount()
    {
        asteroidCount = 0;
    }


    void DebugDrawNewBox(float x, float y)
    {
        Debug.DrawLine(new Vector3(-x, y, 0), new Vector3(x, y, 0));
        Debug.DrawLine(new Vector3(x, y, 0), new Vector3(x, -y, 0));
        Debug.DrawLine(new Vector3(x, -y, 0), new Vector3(-x, -y, 0));
        Debug.DrawLine(new Vector3(-x, -y, 0), new Vector3(-x, y, 0));
    }
}
