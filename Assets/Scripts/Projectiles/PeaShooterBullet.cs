using System;
using UnityEngine;

public class PeaShooterBullet : MonoBehaviour
{

    [SerializeField] float bulletVelocity = 40f;
    [SerializeField] float bulletDistance = 40f;
    Vector3 bulletSpawnPos;

    void Awake()
    {
        Debug.Log(transform.rotation);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Debug.Log("PLAYER DETECTED");
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
