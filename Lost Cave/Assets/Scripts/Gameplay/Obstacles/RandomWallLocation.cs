using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallLocation : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> enemies;
    public List<GameObject> breakableWallsList;
    public GameObject trapDoor;
    public GameObject breakableWall;
    public int maxWalls;
    public int currentWalls = 0;
    public List<Vector2> usedPositions;
    public List<Vector2> reservedPositions;
    public Vector2 trapDoorLocation;

    private bool isRepeated;

    // Start is called before the first frame update
    private void Awake()
    {
        if(maxWalls > 120)
        {
            maxWalls = 120;
        }
        usedPositions.Add(new Vector2(0, 0));
                    
        for (int i = 0; i < maxWalls; i++)
        {
            reservedPositions.Clear();
            reservePositions(player);

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

                for (int e = 0; e < enemies.Count; e++)
                {
                    reservedPositions.Clear();
                    reservePositions(enemies[e]);

                    for (int a = 0; a < reservedPositions.Count; a++)
                    {
                        if (instanciatedWall.transform.position.x == reservedPositions[a].x && instanciatedWall.transform.position.z == reservedPositions[a].y)
                        {
                            i--;
                            Destroy(instanciatedWall);
                            isRepeated = true;
                        }
                    }
                }

                if(!isRepeated)
                {
                    usedPositions.Add(new Vector2(randomLocationIndexX, randomLocationIndexZ));
                    breakableWallsList.Add(instanciatedWall);

                    if (i == maxWalls - 1)
                    {
                        trapDoorLocation.x = instanciatedWall.transform.position.x;
                        trapDoorLocation.y = instanciatedWall.transform.position.z;
                    }
                }
            }
           
        }

        foreach (GameObject wall in breakableWallsList)
        {
            currentWalls++;
        }

        trapDoor.transform.position = new Vector3(trapDoorLocation.x, trapDoor.transform.position.y, trapDoorLocation.y);
    }

    private void reservePositions(GameObject go)
    {
        reservedPositions.Add(new Vector2(go.transform.position.x, go.transform.position.z));

        reservedPositions.Add(new Vector2(go.transform.position.x + 5, go.transform.position.z));
        reservedPositions.Add(new Vector2(go.transform.position.x - 5, go.transform.position.z));

        reservedPositions.Add(new Vector2(go.transform.position.x, go.transform.position.z + 5));
        reservedPositions.Add(new Vector2(go.transform.position.x, go.transform.position.z - 5));

        reservedPositions.Add(new Vector2(go.transform.position.x - 5, go.transform.position.z + 5));
        reservedPositions.Add(new Vector2(go.transform.position.x + 5, go.transform.position.z + 5));

        reservedPositions.Add(new Vector2(go.transform.position.x - 5, go.transform.position.z - 5));
        reservedPositions.Add(new Vector2(go.transform.position.x + 5, go.transform.position.z - 5));
    }

    public int getWallsAmount()
    {
        return currentWalls;
    }
}
