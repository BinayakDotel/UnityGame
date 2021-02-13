using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float move_speed = 2.0f;
    public float smooth_move = 8f;
    public float turn_speed = 0.01f;
    public Vector2 slide_range;

    public void FixedUpdate()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        transform.position += Vector3.forward * move_speed * Time.fixedDeltaTime;
        transform.Rotate(0.0f, -10.0f, 0.0f, Space.Self);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, slide_range.x, slide_range.y),
                                        transform.position.y,
                                        transform.position.z);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = Vector3.Lerp(
                    this.transform.position,
                    new Vector3(
                        transform.position.x + touch.deltaPosition.x * turn_speed * Time.fixedDeltaTime,
                        transform.position.y,
                        transform.position.z),
                        smooth_move * Time.fixedDeltaTime
                    );
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q PRESSED");
            transform.position = Vector3.Lerp(
                    this.transform.position,
                    new Vector3(
                        transform.position.x + -10 * Time.fixedDeltaTime,
                        transform.position.y,
                        transform.position.z),
                        smooth_move * Time.fixedDeltaTime
                    );
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position = Vector3.Lerp(
                    this.transform.position,
                    new Vector3(
                        transform.position.x + 10 * Time.fixedDeltaTime,
                        transform.position.y,
                        transform.position.z),
                        smooth_move * Time.fixedDeltaTime
                    );
        }
    }
}

