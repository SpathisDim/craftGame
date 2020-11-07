
 using UnityEngine;
using System.Collections;

public class ClickOnFaceScript : MonoBehaviour
{

    public Vector3 delta;
    public int DiastasiX = 20;
    public int DiastasiZ = 20;
    
    private static int DestroyClick=0;
    private static int BuildClick=0;


    void OnMouseOver()
    {
        Diastaseis.diastaseis(DiastasiX, DiastasiZ);

        // If the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {   
              
                Debug.Log("Left click!");
                // Destroy the parent of the face we clicked
                Destroy(this.transform.parent.gameObject);
                DestroyClick = DestroyClick + 1;

           // characterController.DestroyPoints(i);
        }

        // If the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
                             
                Debug.Log("Right click!");
                // Call method from WorldGenerator class
                WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                this.transform.parent.gameObject); // The parent GameObject     
                BuildClick = BuildClick + 1;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F click!");
            WorldGenerator.CreateCubeFloor(DiastasiX, DiastasiZ, this.transform.parent.gameObject);
        }
    }

    public static int DClicks()
    {
        return DestroyClick;
    }
    public static int BClicks()
    {
        return BuildClick;
    }

}
