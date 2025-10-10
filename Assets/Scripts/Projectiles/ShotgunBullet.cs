using UnityEngine;

public class ShotgunBullet : Bullet
{
    void Awake()
    {
        FindAnyObjectByType<SoundEffectManager>().PlayBulletSoundEffect();
        bulletSpawnPos = transform.position;
        bulletVelocity = 120f;
        bulletDistance = 20f;
    }

    void Update()
    {
        DoMovement();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid")
        {
            Destroy(gameObject);
        }    
    }
}
