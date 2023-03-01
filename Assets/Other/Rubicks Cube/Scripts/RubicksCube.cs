using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Voxelity.Extensions;
using Voxelity.Timer;

public class RubicksCube : MonoBehaviour
{
    public Transform rotater;
    public Piece piece;
    public GameObject parent;
    public Vector3Int size = new Vector3Int(3, 3, 3);
    public List<Piece> pieces;
    public float gap = 0.33f;
    private Timer timer;
    [SerializeField] private Transform back, forward, top, bottom, left, right;

    public Stack<CubeMovement> moves = new Stack<CubeMovement>();
    public CubeSolution savedSolution;

    public List<CubeMovement> GetSolutionMoves
    {
        get => moves.Reverse().ToList();
    }
    private void Awake()
    {
        if(savedSolution != null)
        {
            foreach (var item in savedSolution.solution)
            {
                moves.Push(item);
            }
        }
    }
    private bool canMove = true;
    public void RotateCube(CubeMovement movement)
    {
        if (!canMove) return;
        canMove = false;
        movement.Execute(this);
        moves.Push(movement);
    }
    public void MoveBack()
    {
        if (moves.Count == 0)
        {
            canMove = true;
            return;
        }

        moves.Pop().Undo(this);
        canMove = false;
        timer = new Timer(0.4f).OnComplete(() =>
        {
            MoveBack();
        });
    }
    public void RotateSelectedObjects(Piece[] selectedObjs, Vector3Int dimension, bool clockWise)
    {
        rotater.localEulerAngles = Vector3.zero;
        Vector3 pivot = Vector3.zero;
        foreach (var item in selectedObjs)
            pivot += item.transform.position;
        pivot /= selectedObjs.Length;

        rotater.position = pivot;
        foreach (var item in selectedObjs)
            item.transform.SetParent(rotater);

        if (timer != null)
            timer.Complete();

        timer = new Timer(0.3f).OnComplete(() =>
        {
            foreach (var item in selectedObjs)
            {
                item.transform.SetParent(parent.transform);
                item.UpdateCurrentPosition(gap);
            }
            timer = null;
            canMove = true;
        });
        timer.OnUpdate01(x =>
            {
                rotater.localEulerAngles = clockWise ? (Vector3)dimension * 90f * x : -(Vector3)dimension * 90f * x;
            });
    }
    public Piece[] SelectRelatives(Vector3Int pieceIndex, Vector3Int dimension)
    {
        List<Piece> relatives = new List<Piece>();
        Piece mainPiece = null;
        foreach (var item in pieces)
        {
            if(item.StartPosition == pieceIndex)
            {
                mainPiece = item;
                break;
            }
        }
        relatives.Add(mainPiece);
        foreach (var item in pieces)
        {
            if (item == mainPiece) continue;

            if (dimension.x == 1)
            {
                if (item.CurrentPosition.x == mainPiece.CurrentPosition.x && !relatives.Contains(item))
                {
                    relatives.Add(item);
                }
            }
            if (dimension.y == 1)
            {
                if (item.CurrentPosition.y == mainPiece.CurrentPosition.y && !relatives.Contains(item))
                {
                    relatives.Add(item);
                }
            }
            if (dimension.z == 1)
            {
                if (item.CurrentPosition.z == mainPiece.CurrentPosition.z && !relatives.Contains(item))
                {
                    relatives.Add(item);
                }
            }
        }
        return relatives.ToArray();
    }
    public void SetObject()
    {
        parent.transform.GetChildGO().ForEach(x => DestroyImmediate(x));
        pieces.Clear();
        parent.transform.localPosition = Vector3.one * -gap;
        int index = 0;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    pieces.Add(Instantiate(piece, parent.transform));
                    index++;
                }
            }
        }
        SetPoses();
    }
    private void SetPoses()
    {
        int index = 0;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    pieces[index].Setup(new Vector3Int(x, y, z), gap, back, forward, top, bottom, left, right);
                    index++;
                }
            }
        }
    }
}
