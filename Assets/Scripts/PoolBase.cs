using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected int poolSize;

    protected List<GameObject> pool;

    protected virtual void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    protected GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(prefab);

        obj.transform.SetParent(transform);
        obj.SetActive(false);

        pool.Add(obj);

        return obj;
    }

    protected GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateNewObject();
    }
}
