using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.2f; 

    private Vector3 desiredPos;
    private Vector3 smoothPos;

    private void FixedUpdate()
    {
        desiredPos = player.position + offset;
        smoothPos = Vector3.Lerp(this.transform.position, desiredPos, smoothSpeed);
        this.transform.position = new Vector3(
            this.transform.position.x,
            smoothPos.y,
            smoothPos.z);

        //this.transform.LookAt(player);
    }
}