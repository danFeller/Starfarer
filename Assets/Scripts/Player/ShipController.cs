using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.Build.Content;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float velocity = 100f;

    [SerializeField] float cooldownDuration = 0.5f;
    float cooldownIncrement;

    [SerializeField] GameObject bullet;
    [SerializeField] bool allRange = false;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        DoMovement();
        DoRotation();
        DoFire();

        cooldownIncrement += Time.deltaTime;
    }

    void DoFire()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (cooldownIncrement > cooldownDuration)
            {
                Instantiate(bullet, transform.position, transform.rotation).SetActive(true);
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
        if (other.tag == "Enemy" || other.tag == "Asteroid")
        {
            Destroy(gameObject);
            // Debug.Log("YOU DIED");
        }
    }

}
