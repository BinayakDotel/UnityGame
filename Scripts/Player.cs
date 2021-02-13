using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Speed Stat")]
    public float forward_speed = 50f;
    public float sideways_speed = 14f;
    public Vector3 m_EulerAngleVelocity;

    public virtual void Awake()
    {
    }
    public void setForwardSpeed(float speed)
    {
        this.forward_speed = speed;
    }
    public float getForwardSpeed()
    {
        return this.forward_speed;
    }
    public void setSidewaysSpeed(float speed)
    {
        this.sideways_speed = speed;
    }
    public float getSidewaysSpeed()
    {
        return this.sideways_speed;
    }
}
