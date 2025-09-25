using Unity.VisualScripting;
using UnityEngine;

public class ChaserController : EnemyController
{
    [SerializeField] float enemyMaxSpeed = 50f;
    [SerializeField] int points = 100;
    [SerializeField] GameObject bonus;
    [SerializeField] float bonusDropChance = 0.2f;

    GameObject ship;

    Vector3 shipPosition;

    float enemySpeed;
    bool projectileTriggerIsRunning = true;
    bool asteroidTriggerIsRunning = true;
    bool deathPlaneTriggerIsRunning = true;

    static int chaserCount;

    void Awake()
    {
        incrementCounter();
    }

    void Start()
    {
        enemySpeed = Random.Range(20f, enemyMaxSpeed);
        ship = FindFirstObjectByType<ShipController>().gameObject;
    }

    void Update()
    {  
        if (ship.IsDestroyed())
        {
            Flee();
        }
        else
        {
            shipPosition = ship.transform.position;
        }
        PathToShipPosition();
    }

    void PathToShipPosition()
    {
        Vector3 shipPos = CalculateShipPath(shipPosition, transform.position);
        Debug.DrawLine(transform.position, shipPosition);
        transform.Translate(shipPos * Time.deltaTime * enemySpeed);
    }

    Vector3 CalculateShipPath(Vector2 shipPos, Vector2 currentEnemyPos)
    {
        float distanceX = shipPos.x - currentEnemyPos.x;
        float distanceY = shipPos.y - currentEnemyPos.y;

        return new Vector3(distanceX, distanceY, 0f).normalized;
    }

    // void PathToCurrentShipPosition()
    // {
    //     Debug.DrawLine(transform.position, shipPosition);
    //     transform.Translate(shipPosition * Time.deltaTime * enemySpeed);
    // }

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
        return chaserCount;
    }

    public void incrementCounter()
    {
        chaserCount++;
    }
    public void decrementCounter()
    {
        chaserCount--;
    }

    public void resetCount()
    {
        chaserCount = 0;
    }
}
