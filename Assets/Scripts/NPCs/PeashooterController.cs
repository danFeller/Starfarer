using Unity.VisualScripting;
using UnityEngine;

public class PeashooterController : EnemyController
{
    [SerializeField] GameObject psBullet;
    [SerializeField] int points = 250;
    [SerializeField] GameObject bonus;
    [SerializeField] float bonusDropChance = 0.3f;

    static int dasherCount;

    const float pathX = 36f;
    const float pathY = 18f;
    float duration = 2.5f;
    float timeTravelled = 0;

    bool hasFiredBullet = false;
    Rigidbody2D rb;

    void Awake()
    {
        incrementCounter();
    }

    void Start()
    {
        Identify();
        enemySpeed = 20f;
        centerPoint = new Vector2(Random.Range(-pathX, pathX), Random.Range(-pathY, pathY));
        spawnPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Move to the target end position.
    void Update()
    {
        if (transform.position != centerPoint && !isAtCenterPoint)
        {
            PathToCenter();
        }
        else
        {
            isAtCenterPoint = true;
            FireBullet();
            enemySpeed = 40f;
            PathThroughSpawnPos();
        }

        DebugDrawNewBox(pathX, pathY);
    }

    void FireBullet()
    {
        if (ship.IsDestroyed())
        {
            Flee();
        }
        else
        {
            if (!hasFiredBullet)
            {
                shipPosition = ship.transform.position;

                float angleRad = Mathf.Atan2(shipPosition.y - transform.position.y, shipPosition.x - transform.position.x);
                float angleDeg = (180 / Mathf.PI) * angleRad - 90; // Offset this by 90 Degrees
                transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);

                Debug.Log(transform.rotation);
                Instantiate(psBullet, transform.position, transform.rotation).SetActive(true);

                hasFiredBullet = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }

    void PathToCenter()
    {
        rb.MovePosition(Vector2.Lerp(spawnPos, centerPoint, timeTravelled));
        timeTravelled += Time.deltaTime / duration;
    }


    void PathThroughSpawnPos()
    {
        float directionX = centerPoint.x - spawnPos.x;
        float directionY = centerPoint.y - spawnPos.y;

        Vector3 move = new Vector3(-directionX, -directionY, 0f).normalized * enemySpeed * Time.deltaTime;
        transform.Translate(move);
    }






    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 posOfDeath = transform.position;
        if (other.tag == "PlayerProjectile" && projectileTriggerIsRunning)
        {
            projectileTriggerIsRunning = false;
            ScoreManager score = FindFirstObjectByType<ScoreManager>();
            score.SetTotalScore(points);
            decrementCounter();
            if (Random.Range(0f, 1f) <= bonusDropChance)
            {
                Instantiate(bonus.gameObject, posOfDeath, Quaternion.identity).SetActive(true);
            }

            FindAnyObjectByType<SoundEffectManager>().PlayEnemySoundEffect();
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        if (other.tag == "Asteroid" && asteroidTriggerIsRunning)
        {
            asteroidTriggerIsRunning = false;
            FindAnyObjectByType<SoundEffectManager>().PlayEnemySoundEffect();
            decrementCounter();
            Destroy(gameObject);
        }
        if (other.tag == "DeathPlane" && deathPlaneTriggerIsRunning)
        {
            deathPlaneTriggerIsRunning = false;
            decrementCounter();
            Destroy(gameObject);
        }
    }

    public int getCount()
    {
        return dasherCount;
    }
    public void incrementCounter()
    {
        dasherCount++;
    }
    public void decrementCounter()
    {
        dasherCount--;
    }
    public void resetCount()
    {
        dasherCount = 0;
    }

    void DebugDrawNewBox(float x, float y)
    {
        Debug.DrawLine(new Vector3(-x, y, 0), new Vector3(x, y, 0));
        Debug.DrawLine(new Vector3(x, y, 0), new Vector3(x, -y, 0));
        Debug.DrawLine(new Vector3(x, -y, 0), new Vector3(-x, -y, 0));
        Debug.DrawLine(new Vector3(-x, -y, 0), new Vector3(-x, y, 0));
    }
}
