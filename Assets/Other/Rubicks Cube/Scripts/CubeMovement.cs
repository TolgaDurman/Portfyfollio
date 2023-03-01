using UnityEngine;
[System.Serializable]
public struct CubeMovement
{
    [SerializeField]private Vector3Int pieceIndex;
    [SerializeField]private Vector3Int dimension;
    [SerializeField]private bool clockWise;

    public CubeMovement(Vector3Int pieceIndex, Vector3Int dimension, bool clockWise)
    {
        this.pieceIndex = pieceIndex;
        this.dimension = dimension;
        this.clockWise = clockWise;
    }

    public void Execute(RubicksCube cube)
    {
        cube.RotateSelectedObjects(cube.SelectRelatives(pieceIndex,dimension),dimension,clockWise);
    }
    public void Undo(RubicksCube cube)
    {
        cube.RotateSelectedObjects(cube.SelectRelatives(pieceIndex,dimension),dimension,!clockWise);
    }
}
