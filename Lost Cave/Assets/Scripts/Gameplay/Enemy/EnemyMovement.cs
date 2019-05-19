using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum dir
    {
        moveUp,
        moveDown,
        moveLeft,
        moveRight,
        maxMoves
    }

    public int speed;
    public dir enemyDir;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (enemyDir)
        {
            case dir.moveUp:
                transform.position = transform.position + transform.forward * speed * Time.deltaTime;
                break;
            case dir.moveDown:
                transform.position = transform.position + transform.forward * -speed * Time.deltaTime;
                break;
            case dir.moveLeft:
                transform.position = transform.position + transform.right * -speed * Time.deltaTime;
                break;
            case dir.moveRight:
                transform.position = transform.position + transform.right * speed * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}
