using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public int width = 24;
    public int height = 18;

    public GameObject tilePrefab;
    public List<GameObject> tiles;

    private static World _instance;
    
    void OnEnable()
    {
        _instance = this;

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

    public static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(0, _instance.width), Random.Range(0, _instance.height), 0);
    }
}
