using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    private static WorldController _instance;
    public static WorldController Instance { get {
            if (_instance != null) 
                return _instance;
            
            _instance = GameObject.FindObjectOfType<WorldController>();

            if (_instance != null) 
                return _instance;
            
            GameObject worldController = new GameObject();
            _instance = worldController.AddComponent<WorldController>();

            return _instance;
        }
    }


    private Tile[,] tiles;
    [SerializeField] private int width;
    [SerializeField] private int height;

    private void Start()
    {
        _instance = this;
        
        // Creating a world grid
        tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                tiles[x, y] = new Tile(x, y);
    }

    public Tile GetTileAt(int x, int y)
    {
        if (y >= 0 && x >= 0 && x < width && y < height) 
            return tiles[x, y];
        
        Debug.Log("There is no tile for that");
        return null;

    }
}