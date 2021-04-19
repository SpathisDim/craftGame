using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaCube : MonoBehaviour
{
    private Vector3 cubePos;


    private void Update()
    {
       


        if (Input.GetKeyDown(KeyCode.F))
        {
            cubePos = new Vector3(20 / 2, 0.8f, 20 / 2);
            transform.position = cubePos;
        }
    }

    
}
