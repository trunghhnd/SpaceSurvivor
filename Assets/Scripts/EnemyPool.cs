using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : PoolBase
{
    public GameObject GetEnemy(Vector3 position)
    {
        GameObject enemy = GetPooledObject();

        enemy.transform.position = position;
        enemy.SetActive(true);

        return enemy;
    }
}
