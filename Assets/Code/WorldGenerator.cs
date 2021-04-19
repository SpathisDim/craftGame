using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

   

    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
    {


    //clone
    GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);

        //Place
        clone.transform.position = newPosition;
        //rename
        clone.name = "Voxel@" + clone.transform.position;

    }

    public static void CreateCubeFloor(int DiastasiX, int DiastasiZ, GameObject originalGameobject)
    {
        Vector3 spawnLocation;
        Vector3 pos = new Vector3(0, 0, 0);
        

        GameObject myCubefloor = (GameObject)Instantiate(originalGameobject, pos, Quaternion.identity);

        myCubefloor.transform.position = pos;
        myCubefloor.name = "Floor@" + myCubefloor.transform.position;
       

        for (int i = 0; i <= DiastasiX; i++)
        {
            for (int j = 0; j <= DiastasiZ; j++)
            {
                spawnLocation = new Vector3(i, 0.2f, j);
                Instantiate(myCubefloor, spawnLocation, Quaternion.identity);

            }
        }
        
    }
}
