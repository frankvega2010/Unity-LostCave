using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public bool canMoveVertical;
    public bool canMoveHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float AxisX = Input.GetAxisRaw("Vertical");
        float AxisZ = Input.GetAxisRaw("Horizontal");

        if(canMoveVertical)
        {
            if (AxisX > 0)
            {
                transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            else if (AxisX < 0)
            {
                transform.position = transform.position + Vector3.forward * -speed * Time.deltaTime;
            }
        }

        if(canMoveHorizontal)
        {
            if (AxisZ > 0)
            {
                transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            }
            else if (AxisZ < 0)
            {
                transform.position = transform.position + Vector3.right * -speed * Time.deltaTime;
            }
        }
    }
}
