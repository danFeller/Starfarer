using UnityEngine;

public class PierceBullet : Bullet
{
    void Awake()
    {
        FindAnyObjectByType<SoundEffectManager>().PlayBulletSoundEffect();
        bulletSpawnPos = transform.position;
        bulletVelocity = 90f;
        bulletDistance = 60f;
        CalculateDistance();
    }

    void Update()
    {
        DoMovement();
    }

    void CalculateDistance()
    {
        int power = FindFirstObjectByType<ShipController>().getPowerLevel();
        switch (power)
        {
            case 1:
                bulletDistance = 60f;
                break;
            case 2:
                bulletDistance = 100f;
                break;
            case 3:
                bulletDistance = 150f;
                break;
        }
    }



    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid")
        {
            Destroy(gameObject);
        }    
    }
}
