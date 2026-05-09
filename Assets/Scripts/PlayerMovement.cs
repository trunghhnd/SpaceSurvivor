using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //float speed = 0.3f;
    float minX = -2.2f;
    float maxX = 2.2f;
    float minY = -4.53f;
    float maxY = 4.53f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;
                Vector3 move = new Vector3(delta.x, delta.y, 0) * speed * Time.deltaTime;
                transform.Translate(move);
                Vector3 clampedPos = transform.position;
                clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
                clampedPos.y = Mathf.Clamp(clampedPos.y, minY, maxY);
                transform.position = clampedPos;
            }
        }*/
        /*else
        {*/
            Vector3 inputPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(inputPos);
            worldPos.z = 0;
            worldPos.x = Mathf.Clamp(worldPos.x, minX, maxX);
            worldPos.y = Mathf.Clamp(worldPos.y, minY, maxY);
            transform.position = worldPos;
        /*}*/
    }
}

