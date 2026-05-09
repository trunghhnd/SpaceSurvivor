using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisableOutOfBounds : MonoBehaviour
{
    private float minX = -3f;
    private float maxX = 3f;
    private float maxY = 5.5f;
    private float minY = -5.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBounds();
    }
    private void CheckOutOfBounds()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        if (posX < minX || posX > maxX || posY < minY || posY > maxY)
        {
            gameObject.SetActive(false);
        }
    }
}
