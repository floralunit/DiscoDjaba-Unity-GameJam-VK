using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] public int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {   
        
        GenerateGrid();

    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(this.transform.position.x + x, this.transform.position.y + y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                System.Random rnd = new System.Random();
                int num = rnd.Next(1, 5);
                spawnedTile.Init();

                _tiles[new Vector2(this.transform.position.x + x, this.transform.position.y + y)] = spawnedTile;
            }
        }

        //_cam.transform.position = new Vector3((float)_width - 0.5f, _height / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}