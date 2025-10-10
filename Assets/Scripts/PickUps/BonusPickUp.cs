using UnityEngine;

public class BonusPickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;

    SoundEffectManager itemSound;

    void Start()
    {
        Invoke("Disappear", 5f);
        itemSound = FindFirstObjectByType<SoundEffectManager>();
    }

    void Update()
    {
        DoRotation();
    }

    void Disappear()
    {
        Destroy(gameObject);
    }

    void DoMovement()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void DoRotation()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.tag == "Bonus")
        {
            itemSound.PlayItemGetSound();
            ScoreManager score = FindFirstObjectByType<ScoreManager>();
            score.SetStarScore(0.1f);
            Destroy(gameObject);
            Debug.Log("BONUS");
        }
        if (other.tag == "Player" && gameObject.tag == "Upgrade")
        {
            itemSound.PlayItemGetSound();
            ScoreManager score = FindFirstObjectByType<ScoreManager>();
            score.SetStarScore(0.5f);
            ShipController ship = FindFirstObjectByType<ShipController>();
            ship.increasePower();
            Destroy(gameObject);
            Debug.Log("UPGRADE");
        }
    }
}
