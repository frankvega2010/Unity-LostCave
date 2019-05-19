using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject bombParent;
    public float explosionDurationTime;

    private float explosionTime;
    private Bomb bomb;

    private void Start()
    {
        bomb = bombParent.GetComponent<Bomb>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionTime += Time.deltaTime;

        if(explosionTime >= explosionDurationTime)
        {
            bomb.Destroy();
        }
    }
}
