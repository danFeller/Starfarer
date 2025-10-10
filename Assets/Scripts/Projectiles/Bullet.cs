using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float bulletVelocity;
    protected float bulletDistance;
    protected Vector3 bulletSpawnPos;

    protected void DoMovement()
    {
        if (BulletHasTravelled())
        {
            Destroy(gameObject);
        }
        transform.Translate(0f, bulletVelocity * Time.deltaTime, 0f);
    }

    protected bool BulletHasTravelled()
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
