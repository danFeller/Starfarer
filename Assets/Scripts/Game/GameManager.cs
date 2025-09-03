using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

// The following game was pushed to GitHub on September 3, 2025. This comment was made to ensure the workflow "flowed" and I could commit changes on the desktop Git Application.

public class GameManager : MonoBehaviour
{
    const float waveTime = 10f;
    [SerializeField] Slider slider;
    [SerializeField] GameObject ship;
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject chaser;
    [SerializeField] List<LevelSO> levels;

    [SerializeField] TextMeshProUGUI levelNumber;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI starText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;

    [SerializeField] Button retryButton;
    [SerializeField] Button mainMenuButton;

    int currentWaveNumber = 0;
    bool isCurrentWaveChanging = true;
    bool isGameOver = false;
    bool isGamePaused = false;

    void Start()
    {
        Time.timeScale = 1;
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isGamePaused)
        {
            isGamePaused = true;
            levelNumber.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            starText.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (!isGameOver)
        {
            levelNumber.text = "Level: " + levels[currentWaveNumber].level;
            if (ship.IsDestroyed())
            {
                levelNumber.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(false);
                starText.gameObject.SetActive(false);
                retryButton.gameObject.SetActive(true);
                mainMenuButton.gameObject.SetActive(true);

                loseText.gameObject.SetActive(true);
                int totalScore = FindFirstObjectByType<ScoreManager>().GetScore();
                loseText.text = "You Lose... Score: " + totalScore;
            }
            slider.value -= Time.deltaTime;
            IsWaveOver();
        }
        else
        {
            levelNumber.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            starText.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);

            winText.gameObject.SetActive(true);
            int totalScore = FindFirstObjectByType<ScoreManager>().GetScore();
            winText.text = "YOU WIN! Score: " + totalScore;
        }
    }

    void IsWaveOver()
    {
        if (slider.value == 0 && AreAllEnemiesGone())
        {
            isCurrentWaveChanging = true;
            Invoke("StartNewWave", 4f);
        }
    }

    void StartNewWave()
    {
        if (levels.Count == 0)
        {
            slider.value = 0f;
            isGameOver = true;
        }
        else
        {
            if (isCurrentWaveChanging)
            {
                isCurrentWaveChanging = false;
                slider.value = waveTime;
                levels.RemoveAt(0);
            }
        }
    }

    public bool AreAllEnemiesGone()
    {
        if (asteroid.GetComponent<AsteroidController>().getCount() == 0 && chaser.GetComponent<ChaserController>().getCount() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<LevelSO> GetLevels()
    {
        return levels;
    }
    public bool GetWaveChange()
    {
        return isCurrentWaveChanging;
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}
