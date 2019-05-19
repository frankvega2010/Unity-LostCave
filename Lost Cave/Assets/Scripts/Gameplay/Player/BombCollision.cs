using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollision : MonoBehaviour
{
    public GameObject bomb;

    private Bomb bombParent;

    private void Start()
    {
        bombParent = bomb.GetComponent<Bomb>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("owo");
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("UwU");
            bombParent.switchOnce = false;
            gameObject.SetActive(false);
        }
    }
}
