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
            player.transform.position = new Vector3(Mathf.Round(player.transform.position.x), player.transform.position.y, Mathf.Round(player.transform.position.z));
        }


        Debug.Log("hit");
    }

    private void OnCollisionExit(Collision collision)
    {
        //player.GetComponent<PlayerMovement>().canMoveHorizontal = true;
        //player.GetComponent<PlayerMovement>().canMoveVertical = true;
        Debug.Log("not hit");
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.tag == "wall")
    //    {
    //        Debug.Log("hit");
    //        playerModel.GetComponent<MeshRenderer>().material.color = color;
    //        player.GetComponent<PlayerMovement>().canMoveHorizontal = false;
    //        player.GetComponent<PlayerMovement>().canMoveVertical = false;
    //    }
    //}

    //private void OnTriggerExit(Collider collision)
    //{
    //    if (collision.gameObject.tag == "wall")
    //    {
    //        Debug.Log("hit");
    //        playerModel.GetComponent<MeshRenderer>().material.color = Color.white;
    //        player.GetComponent<PlayerMovement>().canMoveHorizontal = true;
    //        player.GetComponent<PlayerMovement>().canMoveVertical = true;
    //    }
    //}
}
