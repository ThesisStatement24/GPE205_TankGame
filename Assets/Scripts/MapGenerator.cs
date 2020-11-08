using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int rows;
    public int cols;
    public float tileWidth = 50.0f;
    public float tileHeight = 50.0f;

    public bool useSeed;
    public bool isMapOfTheDay;
    public int seed;
    
    public Room[,] rooms;
    public Room[] roomTemplates;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap()
    {
        //if have a seed, then seed the RNG
        if (useSeed)
        {
            if (isMapOfTheDay)
            {
                seed = (DateTime.Now.Year*10000) + (DateTime.Now.Month * 100) + DateTime.Now.Day;
            }
            UnityEngine.Random.InitState(seed);
        }

        //If this is to be random, then seed with a random number
        UnityEngine.Random.InitState(UnityEngine.Random.Range(0, 9999));

        //Create that rooms array
        rooms = new Room[cols, rows];

        //For every row that needs to be created
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            //For every col that needs to be created
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                //create a new random room
                GameObject tempRoom = Instantiate(GetRandomRoom().gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                //Move the room to the appropriate place
                tempRoom.transform.position = new Vector3(currentCol * tileWidth, 0.0f, currentRow * -tileHeight);
                //Name the room in a way that we can recognize
                tempRoom.name = "Room (" + currentCol + " , " + currentRow + ")";
                //Make thies room a child of THIS object
                tempRoom.transform.parent = this.transform;
                //save that room in the correct location in the array
                rooms[currentCol, currentRow] = tempRoom.GetComponent<Room>();
                //open the appropriate doors for that room
                //If not on the top row
                if(currentRow != 0)
                {
                    //Deactivate North Door
                    rooms[currentCol, currentRow].doorNorth.SetActive(false);
                }
                //If not on the bottom row
                if (currentRow != rows - 1)
                {
                    //Deactivate South Door
                    rooms[currentCol, currentRow].doorSouth.SetActive(false);
                }
                //If not on the first col
                if (currentCol != 0)
                {
                    //Deactivate West Door
                    rooms[currentCol, currentRow].doorWest.SetActive(false);
                }
                //If not on the last col
                if (currentCol != cols - 1)
                {
                    //Deactivate East Door
                    rooms[currentCol, currentRow].doorEast.SetActive(false);
                }

            }

        }

    }

    public Room GetRandomRoom()
    {

        int randomNumber = UnityEngine.Random.Range(0, roomTemplates.Length);
        return roomTemplates[randomNumber];

    }

}
