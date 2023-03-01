using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;

public class MouseInput : MonoBehaviour
{
    public Camera cam;
    public RubicksCube cube;

    public Piece[] selectedObjs;
    public Vector3Int dimension;
    private Piece piece;

    private void Update()
    {
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition.WithZ(100f)),out var hit,100f))
        {
            if(hit.transform.TryGetComponent<Piece>(out piece))
            {
                selectedObjs = cube.SelectRelatives(piece.StartPosition,dimension);
                foreach (var item in selectedObjs)
                {
                    item.Hover(true);
                }
            }
        }
        else
        {
            piece =null;
            selectedObjs = new Piece[0];
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            dimension = new Vector3Int(1,0,0);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            dimension = new Vector3Int(0,1,0);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            dimension = new Vector3Int(0,0,1);
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            cube.MoveBack();
        }
        if(piece == null) return;
        if(Input.GetMouseButtonDown(0))
        {
            cube.RotateCube(new CubeMovement(piece.StartPosition,dimension,false));
        } 
        if(Input.GetMouseButtonDown(1))
        {
            cube.RotateCube(new CubeMovement(piece.StartPosition,dimension,true));
        }
    }
}
