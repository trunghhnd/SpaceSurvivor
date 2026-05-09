using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        gameUI.SetActive(false);   
        pauseUI.SetActive(true);   
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        gameUI.SetActive(true);   
        pauseUI.SetActive(false);  
        isPaused = false;
    }
    public void Mute()
    {
        AudioManager.Instance.PauseMusic();
    }

    public void TurnOnSound()
    {
        AudioManager.Instance.ResumeMusic();
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
