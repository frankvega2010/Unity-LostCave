using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject UIFinishPanel;
    public GameObject player;
    public List<GameObject> enemies;
    public GameObject wallGenerator;
    public GameObject trapDoorModel;
    public int ChangeSceneTime;

    private int wallsLeft = 0;
    private int lastPlayerLives;
    private float changingSceneTimer;
    private Vector3 playerSpawnLocation;

    private bool canLose = false;
    private bool canWin = false;

    private PlayerStatus playerStatus;
    private PlayerMovement playerMovement;
    private PlayerCollision playerCollision;
    private RandomWallLocation randomWallLocation;
    private List<EnemyStatus> enemiesStatus = new List<EnemyStatus>();
    private UIFinishPanel finishPanel;

    private MeshRenderer trapDoorRenderer;
    private BoxCollider trapDoorCollider;

    // Start is called before the first frame update
    private void Start()
    {
        trapDoorRenderer = trapDoorModel.GetComponent<MeshRenderer>();
        trapDoorCollider = trapDoorModel.GetComponentInParent<BoxCollider>();

        playerStatus = player.GetComponent<PlayerStatus>();
        playerCollision = player.GetComponent<PlayerCollision>();
        playerMovement = player.GetComponent<PlayerMovement>();

        lastPlayerLives = playerStatus.getLives();
        playerSpawnLocation = player.transform.position;

        randomWallLocation = wallGenerator.GetComponent<RandomWallLocation>();
        wallsLeft = randomWallLocation.getWallsAmount();

        playerCollision.onPlayerExit = switchToWin;

        finishPanel = UIFinishPanel.GetComponent<UIFinishPanel>();

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
                canLose = true;
            }
            else
            {
                playerRespawn();
            }
            playerCollision.switchToFalse();
        }

        if(enemies.Count <= 0)
        {
            trapDoorRenderer.material.color = Color.green;
            trapDoorCollider.enabled = true;
        }

        if(canLose)
        {
            roundLost();
        }

        if (canWin)
        {
            roundWon();
        }
    }

    private void playerRespawn()
    {
        player.transform.position = playerSpawnLocation;
    }

    private void addPointsEnemyKilled(EnemyStatus enemy)
    {
        playerStatus.addPoints(100);
        enemies.Remove(enemy.gameObject);
        Destroy(enemy.gameObject);   
    }

    public void addPointsWallDestroyed()
    {
        playerStatus.addPoints(10);
    }

    public int getWallsLeft()
    {
        return wallsLeft;
    }

    public void substractWallsLeft()
    {
        wallsLeft--;
    }

    private void switchToWin()
    {
        canWin = true;
    }

    private void roundWon()
    {
        playerMovement.enabled = false;
        finishPanel.executeRoundUI("You Won!", Color.green, playerStatus.getPoints());
        changingSceneTimer += Time.deltaTime;

        if(changingSceneTimer >= ChangeSceneTime)
        {
            SceneManager.LoadScene("Level");
        }
    }

    private void roundLost()
    {
        playerMovement.enabled = false;
        finishPanel.executeRoundUI("You Lost!", Color.red, playerStatus.getPoints());
        changingSceneTimer += Time.deltaTime;

        if (changingSceneTimer >= ChangeSceneTime)
        {
            SceneManager.LoadScene("Level");
        }
    }
}
