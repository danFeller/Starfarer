using System;
using System.Collections;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float velocity = 100f;

    [SerializeField] float cooldownDuration = 0.5f;
    float cooldownIncrement;

    [SerializeField] GameObject defaultBullet;
    [SerializeField] GameObject shotgunBullet;
    [SerializeField] GameObject pierceBullet;
    [SerializeField] bool allRange = false;
    [SerializeField] Animator anim;

    Camera cam;
    bool isInputEnabled = true;
    bool isDeathSoundEffectPlaying = false;

    int powerLevel;
    [SerializeField] bool isWieldingDefault = true;
    [SerializeField] bool isWieldingPierce = false;
    [SerializeField] bool isWieldingShotgun = false;

    void Start()
    {
        cam = Camera.main;
        powerLevel = 1;
    }

    void Update()
    {
        if (isInputEnabled)
        {
            DoMovement();
            DoRotation();
            if (isWieldingDefault)
            {
                DoDefaultFire();
            }
            if (isWieldingShotgun)
            {
                DoShotgunFire();
            }
            if (isWieldingPierce)
            {
                DoPierceFire();
            }
        }

        cooldownIncrement += Time.deltaTime;
    }

    void DoPierceFire()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (cooldownIncrement / 3f > cooldownDuration)
            {
                Instantiate(pierceBullet, transform.position, transform.rotation).SetActive(true);
                cooldownIncrement = 0;
            }
        }
    }

    void DoShotgunFire()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (cooldownIncrement > cooldownDuration)
            {
                Instantiate(shotgunBullet, transform.position, transform.rotation).SetActive(true);
                for (int i = 1; i <= powerLevel; i++)
                {
                    Instantiate(shotgunBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 30f * i)).SetActive(true);
                    Instantiate(shotgunBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, -30f * i)).SetActive(true);
                }
                cooldownIncrement = 0;
            }
        }
    }

    void DoDefaultFire()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (cooldownIncrement * powerLevel > cooldownDuration)
            {
                Instantiate(defaultBullet, transform.position, transform.rotation).SetActive(true);
                cooldownIncrement = 0;
            }
        }
    }

    void DoRotation()
    {
        if (allRange)
        {
            Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

            float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
            float angleDeg = (180 / Mathf.PI) * angleRad - 90; // Offset this by 90 Degrees
            transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void DoMovement()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        float moveX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * velocity * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Asteroid" || other.tag == "EnemyProjectile")
        {
            if (!isDeathSoundEffectPlaying)
            {
                FindFirstObjectByType<SoundEffectManager>().PlayDeathSoundEffect();
                isDeathSoundEffectPlaying = true;
            }

            DoDeathAnimation();
            StartCoroutine(Die());
        }
        if (other.tag == "ShotgunPickup")
        {
            Destroy(other.gameObject);
            isWieldingDefault = false;
            isWieldingPierce = false;
            isWieldingShotgun = true;
            Debug.Log("Picked Up Shotgun");
        }
        if (other.tag == "PiercingPickup")
        {
            Destroy(other.gameObject);
            isWieldingDefault = false;
            isWieldingPierce = true;
            isWieldingShotgun = false;
            Debug.Log("Picked Up Piercing");
        }
        if (other.tag == "DefaultPickup")
        {
            Destroy(other.gameObject);
            isWieldingDefault = true;
            isWieldingPierce = false;
            isWieldingShotgun = false;
            Debug.Log("Picked Up Default");
        }
    }


    void DoDeathAnimation()
    {
        isInputEnabled = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        anim.SetBool("isDead", true);
    }

    IEnumerator Die()
    {
        Debug.Log("Ship Has Died");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


    public void increasePower()
    {
        if (powerLevel < 3)
        {
            powerLevel += 1;
        }
    }
    public int getPowerLevel()
    {
        return powerLevel;
    }
}
