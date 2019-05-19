using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> enemies;

    private Vector3 playerSpawnLocation;
    private PlayerStatus playerStatus;
    private PlayerCollision playerCollision;
    private List<EnemyStatus> enemiesStatus = new List<EnemyStatus>();
    private int lastPlayerLives;

    // Start is called before the first frame update
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
        playerCollision = player.GetComponent<PlayerCollision>();
        
        lastPlayerLives = playerStatus.getLives();
        playerSpawnLocation = player.transform.position;

        foreach (GameObject enemy in enemies)
        {
            enemiesStatus.Add(enemy.GetComponent<EnemyStatus>());
        }

        foreach (EnemyStatus enemyStatus in enemiesStatus)
        {
            enemyStatus.onEnemyKilled = addPointsEnemyKilled;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(lastPlayerLives != playerStatus.getLives())
        {
            lastPlayerLives = playerStatus.getLives();
            if (lastPlayerLives <= 0)
            {
                //roundLost();
            }
            else
            {
                playerRespawn();
            }
            playerCollision.switchToFalse();
        }
    }

    private void playerRespawn()
    {
        player.transform.position = playerSpawnLocation;
    }

    private void addPointsEnemyKilled()
    {
        playerStatus.addPoints(100);
    }
}
