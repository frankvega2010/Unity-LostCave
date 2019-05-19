using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private EnemyMovement enemyMovement;
    //private EnemyMovement.dir currentDir;
    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //currentDir = enemyMovement.enemyDir;

        switch (collision.gameObject.tag)
        {
            case "wall":
                checkDirection();
                break;
            case "breakableWall":
                checkDirection();
                break;
            //case "Player":
            //    collision.gameObject.GetComponent<PlayerStatus>().subtractLives();
            //    break;
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
