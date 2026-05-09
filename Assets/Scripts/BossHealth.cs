using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : HealthBase
{
    public void SetHealthBar(Slider bar)
    {
        healthBar = bar;
    }
    protected override void Die()
    {
        ScoreManager.instance.AddScore(20);
        healthBar.gameObject.SetActive(false);
        GameManager.instance.GameWin();
    }
    void HideHealthBar()
    {
        healthBar.gameObject.SetActive(false);
    }
}
