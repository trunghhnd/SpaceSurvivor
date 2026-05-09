using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    [SerializeField] private GameObject bulletEnemy;
    private BulletBossPool bulletPool;
    [SerializeField] private Transform firePoint;
    private int bulletCount = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(BulletBossPool pool)
    {
        bulletPool = pool;
    }
    public void ShootCircle()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * Mathf.PI * 2 / bulletCount;
            Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

            GameObject bullet = bulletPool.GetBullet(firePoint.position, Quaternion.identity);
            if (bullet != null)
            {
                bullet.GetComponent<BulletEnemy>().SetDirection(dir);
            }
        }
    }

    public void ShootStraight()
    {
        GameObject bullet = bulletPool.GetBullet(firePoint.position, Quaternion.identity);
        if (bullet != null)
        {
            bullet.GetComponent<BulletEnemy>().SetDirection(Vector2.down);
        }
    }
}
