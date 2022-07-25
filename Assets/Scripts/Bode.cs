using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bode : MonoBehaviour
{
    public float RotationZ;

    public bool Left;
    public bool Right;
    public bool Up;
    public bool Down;
    
    public Vector3 position;
    public Vector3 rotation;
    private void Start()
    {
        position = transform.position;
        rotation = transform.eulerAngles;
        RotationZ = transform.eulerAngles.z;
    }
    public void  Move()
    { 
        if (Left)
        {
            position.x += 2;
            rotation.z = 90;
        }
        else
        if (Right)
        {
            position.x -= 2;
            rotation.z = -90;
        }
        else
        if (Up)
        {
            position.y += 2;
            rotation.z = 0;
        }
        else
        if (Down)
        {
            position.y -= 2;
            rotation.z = 180;
        }

        transform.position = position;
        transform.eulerAngles = rotation;
        RotationZ = transform.eulerAngles.y;
    }

    //private void MoveVertical(int value)
    //{
    //    position.y += value;
    //    rotation.z += value * 90;
    //}

    //private void MoveHorizontal(int value)
    //{
    //    position.x += value;
    //    rotation.z += value * 90;
    //}
  
}
