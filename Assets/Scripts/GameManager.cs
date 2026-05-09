using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private bool isGameOver;
    public bool IsGameOver => isGameOver;
    private bool isGameWin;
    public bool IsGameWin => isGameWin;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        HighScoreUpdate();
        Cursor.visible = true;
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0f;
        HighScoreUpdate();
        Cursor.visible = true;
    }
    public void Reset()
    {
        isGameOver = false;
        isGameWin = false;
    }
    public void HighScoreUpdate()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (ScoreManager.instance.Score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", ScoreManager.instance.Score);
        }
    }   
}
