using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementCamera : MonoBehaviour
{
    [SerializeField] Transform topRightBarrier;
    [SerializeField] Transform bottomLeftBarrier;
    [SerializeField] Vector2 scrollLimits;
    [SerializeField] float scrollSpeed=4;
    [SerializeField] float initialSpeed = 15;
    [SerializeField] float speedVsZoomMultiplier;
    float speed;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        speed = Mathf.Lerp(initialSpeed, initialSpeed * speedVsZoomMultiplier, cam.orthographicSize / scrollLimits.y);

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float mouseWheel = -Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed;

        if (mouseWheel > 0 && cam.orthographicSize + mouseWheel < scrollLimits.y)
        {
            cam.orthographicSize += mouseWheel;
        }
        else if (mouseWheel < 0 && cam.orthographicSize + mouseWheel > scrollLimits.x)
        {
            cam.orthographicSize += mouseWheel;
        }

        if (topRightBarrier != null)
        {
            if (transform.position.x >= topRightBarrier.position.x)
            {
                if (movement.x > 0)
                {
                    movement.x = 0;
                }
            }
            if (transform.position.y >= topRightBarrier.position.y)
            {
                if (movement.y > 0)
                {
                    movement.y = 0;
                }
            }
        }
        if (bottomLeftBarrier != null)
        {
            if (transform.position.x <= bottomLeftBarrier.position.x)
            {
                if (movement.x < 0)
                {
                    movement.x = 0;
                }
            }
            if (transform.position.y <= bottomLeftBarrier.position.y)
            {
                if (movement.y < 0)
                {
                    movement.y = 0;
                }
            }
        }

        transform.Translate(movement * Time.deltaTime * speed);
    }
}
