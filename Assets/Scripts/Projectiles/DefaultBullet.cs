using System;
using UnityEngine;

public class YellowBullet : MonoBehaviour
{
    [SerializeField] float bulletVelocity = 120f;
    [SerializeField] float bulletDistance = 60f;
    Vector3 bulletSpawnPos;

    void Awake()
    {
        FindAnyObjectByType<SoundEffectManager>().PlayBulletSoundEffect();
        bulletSpawnPos = transform.position;
    }

    void Update()
    {
        if (BulletHasTravelled())
        {
            Destroy(gameObject);
        }
        transform.Translate(0f, bulletVelocity * Time.deltaTime, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid")
        {
            Destroy(gameObject);
        }    
    }

    bool BulletHasTravelled()
    {
        if (Math.Abs(transform.position.y - bulletSpawnPos.y) > bulletDistance || Math.Abs(transform.position.x - bulletSpawnPos.x) > bulletDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
