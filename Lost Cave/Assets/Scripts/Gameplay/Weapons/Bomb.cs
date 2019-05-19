using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public delegate void onBombAction();
    public onBombAction onBombExploded;

    public GameObject player;
    public GameObject explosion;
    public float ExplosionTime;

    public bool switchOnce = true;
    private Collider bombCollider;
    private Collider playerCollider;
    private float explodeTimer;
    // Start is called before the first frame update
    void Start()
    {
        bombCollider = GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        explodeTimer += Time.deltaTime;

        if (explodeTimer >= ExplosionTime)
        {
            explosion.SetActive(true);
        }

        Physics.IgnoreCollision(bombCollider, playerCollider, switchOnce);
    }

    public void Destroy()
    {
        if (onBombExploded != null)
        {
            onBombExploded();
        }   
        Destroy(gameObject);
    }
}
