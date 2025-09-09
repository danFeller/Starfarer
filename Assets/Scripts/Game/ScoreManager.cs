using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI starText;

    int totalScore = 0;
    float totalStarScore = 1f;
    GameManager gm;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }


    public void SetTotalScore(int score)
    {
        if (!gm.GetIsGameOver())
        {
            totalScore += score;
            scoreText.text = "Score: " + (totalScore * totalStarScore);
        }
    }

    public void SetStarScore(float score)
    {
        if (!gm.GetIsGameOver())
        {
            totalStarScore += score;
            starText.text = "Multiplier: x" + totalStarScore;
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

}

