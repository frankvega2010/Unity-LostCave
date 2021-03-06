﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerModel;
    public int speed;
    public bool canMoveVertical;
    public bool canMoveHorizontal;

    // Update is called once per frame
    void FixedUpdate()
    {
        float AxisX = Input.GetAxisRaw("Vertical");
        float AxisZ = Input.GetAxisRaw("Horizontal");

        if (AxisX > 0)
        {
            transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            playerModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (AxisX < 0)
        {
            transform.position = transform.position + Vector3.forward * -speed * Time.deltaTime;
            playerModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
        }

        if (AxisZ > 0)
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            playerModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else if (AxisZ < 0)
        {
            transform.position = transform.position + Vector3.right * -speed * Time.deltaTime;
            playerModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
        else
        {
        }
    }
}
