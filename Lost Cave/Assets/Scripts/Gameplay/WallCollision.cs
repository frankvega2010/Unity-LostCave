using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "explosion")
        {
            Debug.Log("oooof");
            other.GetComponent<BombExplosionCheck>().destroyMainObject();
        }
    }
}
