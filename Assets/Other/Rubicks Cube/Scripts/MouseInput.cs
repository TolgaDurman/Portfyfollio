using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;

public class MouseInput : MonoBehaviour
{
    public Camera cam;
    public RubicksCube cube;

    public GameObject[] selectedObjs = new GameObject[9];

    private void Update()
    {
        bool isVertical = Input.GetMouseButton(0);
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition.WithZ(100f)),out var hit,100f))
        {
            selectedObjs = cube.GetObjectsWithObj(hit.transform.gameObject,isVertical);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            cube.RotateSelectedObjects(selectedObjs,isVertical,false);
        } 
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            cube.RotateSelectedObjects(selectedObjs,isVertical,true);
        }
    }
}
