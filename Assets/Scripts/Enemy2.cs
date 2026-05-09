using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase
{
    [SerializeField] private float maxX = 2f;
    [SerializeField] private float minX = -2f;
    [SerializeField] private int direction = 1;
    protected override void Move()
    {
        if (transform.position.x >= maxX)
            direction = -1;
        else if (transform.position.x <= minX)
            direction = 1;
        float newX = transform.position.x + direction * speed * Time.deltaTime;
        float newY = transform.position.y - speed * Time.deltaTime;
        transform.position = new Vector3(newX, newY, transform.position.z);
    }    
}
