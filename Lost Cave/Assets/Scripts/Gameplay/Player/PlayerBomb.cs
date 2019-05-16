using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public GameObject bomb;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instanciatedWall = Instantiate(bomb, transform.position, transform.rotation);
        }
    }
}
