using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int mapLength = 10; //Tiles
    [SerializeField] private int mapHeight = 10;
    public GameObject[,] map = new GameObject[10,10];
    public GameObject BaseTile;

    public Vector3 StartingCoordinates = new Vector3(-50, 0, -50);
    void Start()
    {
        for (int i = 0; i < mapLength; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                print(i);
                print(j);
                map[i,j] = (GameObject)Instantiate(BaseTile, StartingCoordinates + new Vector3(i*10,0,j*10), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
