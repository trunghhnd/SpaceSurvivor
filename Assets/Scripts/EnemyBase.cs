using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int damage = 1;
    void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bullet"))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {               
                enemyHealth.TakeDamage(damage);
                WaveManager.instance.EnemyDied();
            }
        }

        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                WaveManager.instance.EnemyDied();
                player.TakeDamage(damage);
            }

            gameObject.SetActive(false);
        }
    }
    protected virtual void HandleInvisible()
    {
        gameObject.SetActive(false);
        WaveManager.instance.EnemyDied();
    }
    protected virtual void OnBecameInvisible()
    {
        HandleInvisible();
    }
    
}
