using UnityEngine;

public class BonusPickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] int points = 50;

    void Start()
    {
        Invoke("Disappear", 5f);
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
        if (other.tag == "Player")
        {
            ScoreManager score = FindFirstObjectByType<ScoreManager>();
            score.SetTotalScore(points);
            score.SetStarScore(1);
            Destroy(gameObject);
        }
    }



}
