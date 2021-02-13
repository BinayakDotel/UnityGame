using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public CharacterController controller;
    public float move_speed = 5.0f;
    public float smooth_move = 0.5f;

    enum ObjectPos { left, middle, right };
    public GameObject leftPos, middlePos, rightPos;
    ObjectPos obj_pos;

    public void Start()
    {
        obj_pos = ObjectPos.middle;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            obj_pos = ObjectPos.left;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            obj_pos = ObjectPos.middle;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            obj_pos = ObjectPos.right;
        }
        moveObject();
    }
    private void moveObject()
    {
        controller.Move(Vector3.forward * move_speed * Time.deltaTime);
        if (obj_pos == ObjectPos.left)
        {
            transform.position = Vector3.Lerp(
                this.transform.position,        //Own Position
                new Vector3(                    //---------------
                leftPos.transform.position.x,   //---------------
                transform.position.y,           //Desired Postion
                transform.position.z),
                smooth_move * Time.fixedDeltaTime
                );
        }
        if (obj_pos == ObjectPos.middle)
        {
            transform.position = Vector3.Lerp(
                this.transform.position,        //Own Position
                new Vector3(                    //---------------
                middlePos.transform.position.x,   //---------------
                transform.position.y,           //Desired Postion
                transform.position.z),
                smooth_move * Time.fixedDeltaTime
                );
        }
        if (obj_pos == ObjectPos.right)
        {
            transform.position = Vector3.Lerp(
                this.transform.position,        //Own Position
                new Vector3(                    //---------------
                rightPos.transform.position.x,   //---------------
                transform.position.y,           //Desired Postion
                transform.position.z),
                smooth_move * Time.fixedDeltaTime
                );
        }
        Debug.Log("Moving: " + obj_pos);
    }
}

