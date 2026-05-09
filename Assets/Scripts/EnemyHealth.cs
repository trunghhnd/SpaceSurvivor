using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 1;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        ScoreManager.instance.AddScore(1);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        health = 1;
        isDead = false;
    }
}
