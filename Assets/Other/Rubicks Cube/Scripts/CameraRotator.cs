using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;

public class CameraRotator : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(transform.localEulerAngles.y+Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(transform.localEulerAngles.y+Time.deltaTime * -speed);
        }
    }
}
