using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI starText;

    int totalScore = 0;
    int totalStarScore = 0;
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
            scoreText.text = "Score: " + totalScore;
        }
    }

    public void SetStarScore(int score)
    {
        if (!gm.GetIsGameOver())
        {
            totalStarScore += 1;
            starText.text = "Stars: " + totalStarScore;
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

}

