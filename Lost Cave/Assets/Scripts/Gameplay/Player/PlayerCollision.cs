using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public delegate void onPlayerAction();
    public onPlayerAction onPlayerExit;
    public GameObject player;

    private bool switchOnce;
    private PlayerStatus playerStatus;
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finalExplosion")
        {
            receivedDamage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "enemy":
                receivedDamage();
                break;
            case "exit":
                if(onPlayerExit != null)
                {
                    onPlayerExit();
                }
                break;
            default:
                break;
        }
    }

    private void receivedDamage()
    {
        if (!switchOnce)
        {
            playerStatus.subtractLives();
            switchOnce = true;
        }
    }

    public void switchToFalse()
    {
        switchOnce = false;
    }

    public void switchToTrue()
    {
        switchOnce = true;
    }
}
