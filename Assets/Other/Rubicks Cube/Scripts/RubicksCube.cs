using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;
using Voxelity.Timer;

public class RubicksCube : MonoBehaviour
{
    public Transform rotater;
    public GameObject piece;
    public GameObject parent;
    public Vector3Int size = new Vector3Int(3, 3, 3);
    public List<GameObject> pieces;
    public float gap = 0.33f;
    private Timer timer;

    public GameObject[] GetObjectsWithObj(GameObject obj, bool isVertical)
    {
        foreach (var item in pieces)
        {
            item.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        GameObject[] selecteds = NameConversion(ToV3Int(obj.name), isVertical);
        foreach (var item in selecteds)
        {
            item.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        return selecteds;
    }
    public void RotateSelectedObjects(GameObject[] selectedObjs, bool isVertical, bool clockWise)
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
                item.transform.SetParent(parent.transform);
            
            SetNames();
            timer = null;
        });
        timer.OnUpdate01(x =>
            {
                if (isVertical)
                {
                    rotater.localEulerAngles = clockWise ? new Vector3(90f * x, 0f, 0f) : new Vector3(90f * -x, 0f, 0f);
                }
                else
                {
                    rotater.localEulerAngles = clockWise ? new Vector3(0f, 90f * x) : new Vector3(0f, 90f * -x);
                }
            });
    }


    [ContextMenu(nameof(SetObject))]
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
        SetNames();
    }

    private void SetNames()
    {
        foreach (var item in pieces)
        {
            Vector3 localPos = item.transform.localPosition;
            Vector3Int pos = new Vector3Int(Mathf.RoundToInt(localPos.x / gap), Mathf.RoundToInt(localPos.y / gap), Mathf.RoundToInt(localPos.z / gap));
            item.name = ToString(pos);
        }
    }
    private string ToString(Vector3Int value)
    {
        return $"{value.x},{value.y},{value.z}";
    }
    private Vector3Int ToV3Int(string value)
    {
        string[] valuesString = value.Split(",");
        int.TryParse(valuesString[0], out int x);
        int.TryParse(valuesString[1], out int y);
        int.TryParse(valuesString[2], out int z);
        Vector3Int returned = new Vector3Int(x,y,z);
        return returned;
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
                    pieces[index].transform.localPosition = new Vector3(gap*x,gap*y,gap*z);
                    index++;
                }
            }
        }
    }
    private GameObject[] NameConversion(Vector3Int dimension, bool isVertical)
    {
        GameObject[] dimensionObjects = new GameObject[9];
        int addedIndex = 0;
        for (int i = 0; i < pieces.Count; i++)
        {
            Vector3Int objDimension = ToV3Int(pieces[i].name);
            if (isVertical)
            {
                if (objDimension.x == dimension.x)
                {
                    dimensionObjects[addedIndex] = pieces[i];
                    addedIndex++;
                }
            }
            else
            {
                if (objDimension.y == dimension.y)
                {
                    dimensionObjects[addedIndex] = pieces[i];
                    addedIndex++;
                }
            }
        }
        return dimensionObjects;
    }
}
