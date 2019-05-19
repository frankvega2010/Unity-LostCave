using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public delegate void onEnemyAction(EnemyStatus enemy);
    public onEnemyAction onEnemyKilled;

    public void killEnemy()
    {
        if (onEnemyKilled != null)
        {
            onEnemyKilled(this);
        }
       // Destroy(gameObject);
    }
}
