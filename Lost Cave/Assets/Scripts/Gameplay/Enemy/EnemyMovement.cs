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

    public GameObject enemyModel;
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
                enemyModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case dir.moveDown:
                transform.position = transform.position + transform.forward * -speed * Time.deltaTime;
                enemyModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                break;
            case dir.moveLeft:
                transform.position = transform.position + transform.right * -speed * Time.deltaTime;
                enemyModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                break;
            case dir.moveRight:
                transform.position = transform.position + transform.right * speed * Time.deltaTime;
                enemyModel.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;
            default:
                break;
        }
    }
}
