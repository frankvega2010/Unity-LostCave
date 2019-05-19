using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallCollision : MonoBehaviour
{
    public GameObject GameManagerGameObject;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManagerGameObject.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finalExplosion")
        {
            gameManager.addPointsWallDestroyed();
            Destroy(gameObject);
        }
    }
}
