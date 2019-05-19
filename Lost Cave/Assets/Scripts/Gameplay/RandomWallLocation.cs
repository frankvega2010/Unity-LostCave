using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallLocation : MonoBehaviour
{
    public GameObject player;
    public GameObject trapDoor;
    public GameObject breakableWall;
    public int maxWalls;
    public List<Vector2> usedPositions;
    public List<Vector2> reservedPositions;
    public Vector2 trapDoorLocation;

    private bool isRepeated;

    // Start is called before the first frame update
    private void Start()
    {
        if(maxWalls > 120)
        {
            maxWalls = 120;
        }
        usedPositions.Add(new Vector2(0, 0));
        reservedPositions.Add(new Vector2(player.transform.position.x, player.transform.position.z));

        reservedPositions.Add(new Vector2(player.transform.position.x + 5, player.transform.position.z));
        reservedPositions.Add(new Vector2(player.transform.position.x - 5, player.transform.position.z));

        reservedPositions.Add(new Vector2(player.transform.position.x, player.transform.position.z + 5));
        reservedPositions.Add(new Vector2(player.transform.position.x, player.transform.position.z - 5));

        reservedPositions.Add(new Vector2(player.transform.position.x - 5, player.transform.position.z + 5));
        reservedPositions.Add(new Vector2(player.transform.position.x + 5, player.transform.position.z + 5));

        reservedPositions.Add(new Vector2(player.transform.position.x - 5, player.transform.position.z - 5));
        reservedPositions.Add(new Vector2(player.transform.position.x + 5, player.transform.position.z - 5));
                    
        for (int i = 0; i < maxWalls; i++)
        {
            isRepeated = false;
            int randomLocationIndexX = Random.Range(-19, 20);
            int randomLocationIndexZ = Random.Range(-1, 10);

            while (randomLocationIndexX % 2 == 0 && randomLocationIndexZ % 2 == 0)
            {
                randomLocationIndexX = Random.Range(-19, 20);
                randomLocationIndexZ = Random.Range(-1, 10);
            }

            for (int c = 0; c < usedPositions.Count; c++)
            {
                Vector2 currentPosition = new Vector2(randomLocationIndexX, randomLocationIndexZ);

                if (usedPositions[c] == currentPosition)
                {
                    isRepeated = true;
                }
            }

            if(randomLocationIndexX == player.transform.position.x && randomLocationIndexZ == player.transform.position.z)
            {
                isRepeated = true;
            }

            if (isRepeated)
            {
                i--;
            }
            else
            {
                
                GameObject instanciatedWall = Instantiate(breakableWall, new Vector3(randomLocationIndexX * 5, 3, randomLocationIndexZ * 5), breakableWall.transform.rotation);
                instanciatedWall.SetActive(true);

                for (int b = 0; b < reservedPositions.Count; b++)
                {
                    if(instanciatedWall.transform.position.x == reservedPositions[b].x && instanciatedWall.transform.position.z == reservedPositions[b].y)
                    {
                        i--;
                        Destroy(instanciatedWall);
                        isRepeated = true;
                    }
                }

                if(!isRepeated)
                {
                    usedPositions.Add(new Vector2(randomLocationIndexX, randomLocationIndexZ));

                    if (i == maxWalls - 1)
                    {
                        trapDoorLocation.x = instanciatedWall.transform.position.x;
                        trapDoorLocation.y = instanciatedWall.transform.position.z;
                    }
                }
            }
           
        }

        trapDoor.transform.position = new Vector3(trapDoorLocation.x, trapDoor.transform.position.y, trapDoorLocation.y);
    }
}
