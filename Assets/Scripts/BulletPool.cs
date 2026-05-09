using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : PoolBase
{
    public GameObject GetBullet()
    {
        return GetPooledObject();
    }
}
