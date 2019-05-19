using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public GameObject bomb;

    public bool canFire = true;
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            GameObject instanciatedBomb = Instantiate(bomb, transform.position, transform.rotation);
            Bomb bombInstance = instanciatedBomb.GetComponent<Bomb>();

            instanciatedBomb.SetActive(true);
            bombInstance.onBombExploded = EnableFire;

            canFire = false;
        }
    }

    private void EnableFire()
    {
        canFire = true;
    }
}
