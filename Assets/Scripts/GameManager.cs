using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance; 
    int score ;
    public TextMeshProUGUI text_Score_in_game;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance);
        }
        btnRestart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        score = 0;
        UpdateScore();
        isGameStart = false;
        Time.timeScale = 0;
    }
    public bool isGameStart = false;
    public void StartGame()
    {
        Time.timeScale = 1;
        isGameStart = true;
       
    }
    public void AddScore(int poin)
    {
        score += poin;
        UpdateScore();
    }
    private void UpdateScore()
    {
        text_Score_in_game.text = score.ToString();
    }
    [Space, Header("Game OVER")]
    public GameObject gameOverScreen;
    public Text score_text;
    public Text scoreHigh_text;
    public Button btnRestart;
    public int HighScore
    {
        get => PlayerPrefs.GetInt("HighScore", 0);
        set
        {
            if (value > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", value);
            }
        }
    }
    public void ShowGameOver()
    {
        Time.timeScale = 0;
        HighScore = score;
        gameOverScreen.SetActive(true);
        score_text.text = string.Format($"Score:{score}");
        scoreHigh_text.text = string.Format($"Max Score:{HighScore}");
        return;
    }


}
