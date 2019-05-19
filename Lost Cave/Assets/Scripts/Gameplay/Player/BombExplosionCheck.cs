using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionCheck : MonoBehaviour
{
    public GameObject mainObject;

    public void destroyMainObject()
    {
        Destroy(mainObject);
        Destroy(gameObject);
    }
}
