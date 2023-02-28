using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicksCube : MonoBehaviour
{
    public Vector3Int size = new Vector3Int(3, 3, 3);
    public List<GameObject> pieces;

    [ContextMenu(nameof(SetNames))]
    public void SetNames()
    {
        int index = 0;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    pieces[index].name = $"{x},{y},{z}";
                    index++;
                }
            }
        }
    }
    private GameObject[] NameConversion(Vector3Int dimension)
    {
        GameObject[] dimensionObjects = new GameObject[9];
        for (int i = 0; i < pieces.Count; i++)
        {
            
        }
    }
    private Vector3Int GetNameToVector(string name)
    {
        string[] valuesString = name.Split(",");
        int[] valuesInt = new int[3];
        for (int i = 0; i < valuesInt.Length; i++)
        {
            valuesInt[i] = Convert.ToInt32(valuesString[i]);
        }
        return new Vector3Int(valuesInt[0],valuesInt[1],valuesInt[2]);
    }
}
