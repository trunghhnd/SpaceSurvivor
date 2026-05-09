using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }
    public void PlayGame()
    {       
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
