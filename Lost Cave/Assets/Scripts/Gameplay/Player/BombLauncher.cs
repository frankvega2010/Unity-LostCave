using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public GameObject bomb;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instanciatedBomb = Instantiate(bomb, transform.position, transform.rotation);
            instanciatedBomb.SetActive(true);


            //instanciatedBomb.transform.position = new Vector3(Mathf.Round(instanciatedBomb.transform.position.x), instanciatedBomb.transform.position.y, Mathf.Round(instanciatedBomb.transform.position.z));

            //while(instanciatedBomb.transform.position.x % 2 != 0)
            //{
            //    instanciatedBomb.transform.position = new Vector3(instanciatedBomb.transform.position.x + 1, instanciatedBomb.transform.position.y, instanciatedBomb.transform.position.z);
            //}

            //while (instanciatedBomb.transform.position.z % 2 != 0)
            //{
            //    instanciatedBomb.transform.position = new Vector3(instanciatedBomb.transform.position.x, instanciatedBomb.transform.position.y, instanciatedBomb.transform.position.z + 1);
            //}
        }
    }
}
