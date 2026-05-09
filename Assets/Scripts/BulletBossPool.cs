using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossPool : PoolBase
{   
    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = GetPooledObject();

        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        bullet.SetActive(true);

        return bullet;
    }
    
}
