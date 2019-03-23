using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public int width = 30;
    public int height = 24;

    public GameObject tilePrefab;
    public List<GameObject> tiles;
    
    void OnEnable()
    {
        Debug.Log("Creating world");

        if (tiles != null)
        {
            foreach (GameObject t in tiles)
            {
                DestroyImmediate(t);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject g = Instantiate(tilePrefab, new Vector3(x, y, 1), Quaternion.identity, transform) as GameObject;
                tiles.Add(g);
            }
        }

        Camera.main.transform.position = new Vector3(width - 1, height - 1, -20) / 2;
    }
}
