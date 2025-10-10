using Unity.VisualScripting;
using UnityEngine;

public class DasherController : EnemyController
{

    [SerializeField] int points = 250;
    [SerializeField] GameObject bonus;
    [SerializeField] GameObject upgrade;
    [SerializeField] float bonusDropChance = 0.3f;
    [SerializeField] float upgradeDropChance = 0.1f;
    [SerializeField] Animator anim;

    static int dasherCount;

    const float pathX = 36f;
    const float pathY = 18f;
    float duration = 3;
    float timeTravelled = 0;

    Rigidbody2D rb;

    void Awake()
    {
        incrementCounter();
        ship = FindFirstObjectByType<ShipController>().gameObject;
    }

    void Start()
    {
        Identify();
        centerPoint = new Vector2(Random.Range(-pathX, pathX), Random.Range(-pathY, pathY));
        spawnPos = transform.position;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Move to the target end position.
    void Update()
    {
        if (!ship.IsDestroyed())
        {
            if (transform.position != centerPoint && !isAtCenterPoint)
            {
                Debug.Log("pathing to center");
                PathToCenter();
            }
            else
            {
                isAtCenterPoint = true;
                anim.SetBool("isPausing", true);
                Debug.Log("pathing to Ship");
                PathToDirection();
            }
        } else
        {
            Flee();
        }

        DebugDrawNewBox(pathX, pathY);
    }


    void PathToCenter()
    {
        rb.MovePosition(Vector2.Lerp(spawnPos, centerPoint, timeTravelled));
        timeTravelled += Time.deltaTime / duration;
    }

    void PathToDirection()
    {
        if (ship.IsDestroyed())
        {
            Flee();
        }
        else
        {
            if (!hasShipPos)
            {
                setShipPosition();
                enemySpeed *= 3f;
                hasShipPos = true;
            }
            float directionX = shipPosition.x - centerPoint.x;
            float directionY = shipPosition.y - centerPoint.y;

            Vector3 move = new Vector3(directionX, directionY, 0f).normalized * enemySpeed * Time.deltaTime;
            transform.Translate(move);
        }
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
            if (Random.Range(0f, 1f) <= upgradeDropChance)
            {
                Instantiate(upgrade.gameObject, posOfDeath, Quaternion.identity).SetActive(true);
            }

            FindAnyObjectByType<SoundEffectManager>().PlayEnemySoundEffect();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "PlayerPiercingProjectile" && projectilePiercingTriggerIsRunning)
        {
            projectilePiercingTriggerIsRunning = false;
            ScoreManager score = FindFirstObjectByType<ScoreManager>();
            score.SetTotalScore(points);
            decrementCounter();
            if (Random.Range(0f, 1f) <= bonusDropChance)
            {
                Instantiate(bonus.gameObject, posOfDeath, Quaternion.identity).SetActive(true);
            }
            if (Random.Range(0f, 1f) <= upgradeDropChance)
            {
                Instantiate(bonus.gameObject, posOfDeath, Quaternion.identity).SetActive(true);
            }
            FindAnyObjectByType<SoundEffectManager>().PlayEnemySoundEffect();
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
