using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finalExplosion")
        {
            //Debug.Log("oooof");
            Destroy(gameObject);
        }
    }
}
