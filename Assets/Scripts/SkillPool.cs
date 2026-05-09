using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPool : PoolBase
{
    [SerializeField] private Transform firePoint;
    public void FireRockets()
    {
        int rocketCount = 5;
        float spreadAngle = 45f;

        for (int i = 0; i < rocketCount; i++)
        {
            GameObject rocket = GetPooledObject();

            rocket.SetActive(true);

            rocket.transform.position = firePoint.position;

            float angle = -spreadAngle / 2 + (spreadAngle / (rocketCount - 1)) * i;
            rocket.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
