using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            //player.transform.position = new Vector3(Mathf.Round(player.transform.position.x), player.transform.position.y, Mathf.Round(player.transform.position.z));
        }
        //Debug.Log("hit");
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("not hit");
    }
}
