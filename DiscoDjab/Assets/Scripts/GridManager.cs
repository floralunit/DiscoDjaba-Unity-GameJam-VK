using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] public int _width, _height;

    [SerializeField] public Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    [SerializeField] public List<Material> colors;
    
    private Dictionary<Vector2, Tile> _tiles;

    public Vector3 WinLocation;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
        WinLocation = ColorDirectionHelp.SetRandomWinLocation();

        StartCoroutine(CallWinLocationFuncRandom());
        StartCoroutine(CallTilesFuncRandom());

    }

    IEnumerator CallWinLocationFuncRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(30f, 40f));// задержка от 1 до 10 секунд
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var tile = GetTileAtPosition(new Vector2(this.transform.position.x + x, this.transform.position.y + y));
                    tile._exit.gameObject.SetActive(false);
                    tile.Init(false);
                }
            }
            WinLocation = ColorDirectionHelp.SetRandomWinLocation();
        }
    }

    IEnumerator CallTilesFuncRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(20f, 30f)); // задержка от 1 до 10 секунд
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    System.Random rnd = new System.Random();
                    int num = rnd.Next(0, colors.Count);
                    var tile = GetTileAtPosition(new Vector2(this.transform.position.x + x, this.transform.position.y + y));
                    tile._color = colors[num].color;
                    //tile._exit.gameObject.SetActive(false);
                    tile.Init(false);
                }
            }
        }
    }


    private void Update()
    {
        Invoke("NewWinLocation", 0f);
    }
    void NewWinLocation()
    {
        var tile = GetTileAtPosition(WinLocation);
        tile._exit.gameObject.SetActive(true);
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
                int num = rnd.Next(0, colors.Count);
                spawnedTile._color = colors[num].color;
                    
                
                spawnedTile.Init(true);

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