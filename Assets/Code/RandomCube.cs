using UnityEngine;
using System.Collections;

public class RandomCube : MonoBehaviour
{
    public Vector3 delta;
    public Vector3 spawnLocation;
    public GameObject myCube;
    public int DiastasiX=20;
    public int DiastasiZ=20;


    // Use this for initialization
    void Start()
    {
        if (myCube != true)
        {
            Debug.Log("myCube not set");
            myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        if (!myCube.GetComponent<Renderer>().enabled == false)
        {
            Debug.Log("myCube not rendered");
            myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        CreateCube();
    }

  

    void CreateCube()
    {
        for (int i = 0; i <= DiastasiX; i++)
        {
            for (int j = 0; j <= DiastasiZ; j++)
            {
                spawnLocation = new Vector3(i, 1, j);
                Instantiate(myCube, spawnLocation, Quaternion.identity);
            }
        }
        
    }
}