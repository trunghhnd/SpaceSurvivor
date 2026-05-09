using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bulletEnemy"))
        {
            collision.gameObject.SetActive(false);
            TakeDamage(1);
        }
    }

    protected override void Die()
    {
        GameManager.instance.GameOver();
        healthBar.gameObject.SetActive(false);
    }
}
