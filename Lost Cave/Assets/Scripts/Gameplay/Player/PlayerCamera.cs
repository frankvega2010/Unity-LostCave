using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    //public Camera playerCamera;
    public Vector3 cameraOffset;
    public Vector3 cameraRotationOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
        transform.rotation = Quaternion.Euler(cameraRotationOffset);
    }
}
