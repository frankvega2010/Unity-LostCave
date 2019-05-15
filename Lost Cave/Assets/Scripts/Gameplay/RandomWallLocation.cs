using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallLocation : MonoBehaviour
{
    public GameObject breakableWall;
    public int maxWalls;
    public List<Vector2> usedPositions;

    private bool isRepeated;
    // Start is called before the first frame update
    private void Start()
    {
        usedPositions.Add(new Vector2(0, 0));

        for (int i = 0; i < maxWalls; i++)
        {
            isRepeated = false;
            int randomLocationIndexX = Random.Range(-20, 21);
            int randomLocationIndexZ = Random.Range(-2, 11);

            while (randomLocationIndexX % 2 == 0 || randomLocationIndexX == 0)
            {
                randomLocationIndexX = Random.Range(-20, 21);
            }

            while (randomLocationIndexZ % 2 == 0 || randomLocationIndexZ == 0)
            {
                randomLocationIndexZ = Random.Range(-2, 11);
            }

            for (int c = 0; c < usedPositions.Count; c++)
            {
                Vector2 currentPosition = new Vector2(randomLocationIndexX, randomLocationIndexZ);

                if (usedPositions[c] == currentPosition)
                {
                    isRepeated = true;
                }
            }


            if (isRepeated)
            {
                i--;
            }
            else
            {
                usedPositions.Add(new Vector2(randomLocationIndexX, randomLocationIndexZ));
                GameObject instanciatedWall = Instantiate(breakableWall, new Vector3(randomLocationIndexX * 5, 3, randomLocationIndexZ * 5), breakableWall.transform.rotation);
                instanciatedWall.SetActive(true);
            }
            
        }
    }
}
