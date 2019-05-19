using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;

    private PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finalExplosion")
        {
            playerStatus.subtractLives();  
        }
    }
}
