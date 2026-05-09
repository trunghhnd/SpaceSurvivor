using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    [SerializeField] private Slider healthBar;
    private Slider newHealthBar;
    private BossHealth bossHealth;
    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private GameObject gameWinImage;
    [SerializeField] private GameObject healthBarPlayer;
    [SerializeField] private GameObject Skill;
    [SerializeField] private GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {
        gameOverImage.SetActive(false);
        gameWinImage.SetActive(false);
        healthBarPlayer.SetActive(true);
        Skill.SetActive(true);
        Pause.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameManager.instance;
        if (gm == null) return;

        if (gm.IsGameOver)
        {
            gameOverImage.SetActive(true);
            if(newHealthBar != null)
            {
                newHealthBar.gameObject.SetActive(false);
            }
            healthBarPlayer.SetActive(false);
            Skill.SetActive(false);
            Pause.SetActive(false);
            gm.Reset();
        }

        if (gm.IsGameWin)
        {
            gameWinImage.SetActive(true);
            healthBarPlayer.SetActive(false);
            Skill.SetActive(false);
            Pause.SetActive(false);
            gm.Reset();
        }
    }
    public void BossHPUI(GameObject newBoss)
    {
        newHealthBar = Instantiate(healthBar);
        newHealthBar.transform.SetParent(GameUI.transform, false);
        newHealthBar.gameObject.SetActive(true);
        bossHealth = newBoss.GetComponent<BossHealth>();
        bossHealth.SetHealthBar(newHealthBar);
    }
}
