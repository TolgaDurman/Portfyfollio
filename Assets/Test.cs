using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform tilesParent;
    private SpriteRenderer[] tiles;

    bool[] visited = new bool[100];

    // Start is called before the first frame update
    void Start()
    {
        tiles = tilesParent.GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine(Solver());
    }

    IEnumerator Solver()
    {
        Debug.Log("Solver started");
        for (int i = 1; i <= 100; i++)
        {
            int current = i;
            int step = 0;
            while (current < 100)
            {
                visited[current - 1] = !visited[current - 1];
                tiles[current - 1].color = visited[current - 1] ? Color.red : Color.green;
                step++;
                current = i * step;
                if (i == 1)
                {
                    current = step;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }

        List<int> openIndex = new List<int>();
        for (int i = 0; i < visited.Length; i++)
        {
            if (!visited[i])
            {
                openIndex.Add(i + 1);
            }
        }

        Debug.Log("Open tiles: " + string.Join(", ", openIndex));
    }
}