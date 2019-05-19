using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private EnemyMovement enemyMovement;
    private EnemyStatus enemyStatus;
    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStatus = GetComponent<EnemyStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finalExplosion")
        {
            Debug.Log("rip");
            // Add points
            // KillEnemy enemyStatus.killEnemy(); // Add delegate onKilledEnemy and apply points in GameManager.
            enemyStatus.killEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "wall":
                checkDirection();
                break;
            case "breakableWall":
                checkDirection();
                break;
            default:
                break;
        }
    }

    private void checkDirection()
    {
        switch (enemyMovement.enemyDir)
        {
            case EnemyMovement.dir.moveUp:
                enemyMovement.enemyDir = EnemyMovement.dir.moveDown;
                break;
            case EnemyMovement.dir.moveDown:
                enemyMovement.enemyDir = EnemyMovement.dir.moveUp;
                break;
            case EnemyMovement.dir.moveLeft:
                enemyMovement.enemyDir = EnemyMovement.dir.moveRight;
                break;
            case EnemyMovement.dir.moveRight:
                enemyMovement.enemyDir = EnemyMovement.dir.moveLeft;
                break;
            default:
                break;
        }
    }
}
