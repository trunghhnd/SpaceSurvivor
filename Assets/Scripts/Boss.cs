using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase
{
    [SerializeField] private float maxX = 1.5f;
    [SerializeField] private float minX = -1.5f;
    [SerializeField] private int direction = 1;
    private Collider2D bossCollider;
    private bool canMove = true;
    private bool reachedY = false;
    public void SetMove(bool value)
    {
        canMove = value;
    }
    protected override void Move()
    {
        if (!canMove) return;
        if (!reachedY)
        {
            bossCollider = GetComponent<Collider2D>();
            bossCollider.enabled = false;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= 2f)
            {
                reachedY = true;
                bossCollider.enabled = true;
            }
        }
        else
        {
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
            if (transform.position.x >= maxX)
                direction = -1;
            else if (transform.position.x <= minX)
                direction = 1;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            BossHealth boss = gameObject.GetComponent<BossHealth>();
            boss.TakeDamage(damage);
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    protected override void HandleInvisible()
    {
        
    }
}
