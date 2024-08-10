using System;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    [SerializeField] private Transform _tileEmpty = null;
    [SerializeField] private int _gridSize = 4;
    [SerializeField] private TilesMovement[] _tiles;

    private TilesMovement[] _solution;
    private int[,] _tilesInt;
    private Camera _camera;

    private bool _isMove;

    public event Action MoveCountChanged;
    public event Action WinChanged;

    private void Awake()
    {
        _tilesInt = new int[_gridSize, _gridSize];
        _solution = new TilesMovement[_tiles.Length];
        _camera = Camera.main;

        Array.Copy(_tiles, _solution, _tiles.Length);

        UpdateTilesArray();

        _isMove = false;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveTile();
        }
    }

    public void Shuffle()
    {
        _isMove = true;

        var random = new System.Random();

        for (int j = 0; j < 600; j++)
        {
            foreach (var tile in _tiles)
            {
                if (tile != null && Vector2.Distance(_tileEmpty.position, tile.TargetPos) <= 7)
                {
                    if (random.Next(2) == 1)
                    {
                        SwapWithEmptyTile(tile);
                        break;
                    }
                }
            }
        }
    }

    private void MoveTile()
    {
        if (!_isMove)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit && Vector2.Distance(_tileEmpty.position, hit.transform.position) <= 7)
        {
            TilesMovement selectedTile = hit.transform.GetComponent<TilesMovement>();
            SwapWithEmptyTile(selectedTile);
            CheckIfSolved();
            MoveCountChanged?.Invoke();
        }
    }

    private void SwapWithEmptyTile(TilesMovement tile)
    {
        Vector2 lastEmptySpacePos = _tileEmpty.position;
        int index = FindTileIndex(tile);

        _tileEmpty.position = tile.TargetPos;
        tile.InitTarget(lastEmptySpacePos);

        _tiles[FindEmptyTileIndex()] = tile;
        _tiles[index] = null;
    }

    private int FindEmptyTileIndex()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            if (_tiles[i] is null)
                return i;
        }

        throw new InvalidOperationException("Empty tile not found!");
    }

    private int FindTileIndex(TilesMovement tile)
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            if (_tiles[i] != null && _tiles[i].Equals(tile))
                return i;
        }

        throw new InvalidOperationException("Tile not found in the array!");
    }

    private void UpdateTilesArray()
    {
        int tileCount = 0;

        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                if (tileCount < _tiles.Length && _tiles[tileCount] != null)
                    _tilesInt[i, j] = _tiles[tileCount].Key;
                else
                    _tilesInt[i, j] = 0;

                tileCount++;
            }
        }
    }

    private void CheckIfSolved()
    {
        for (int i = 0; i < _tiles.Length - 1; i++)
        {
            if (_tiles[i] == null || _solution[i] == null || _tiles[i].Key != _solution[i].Key)
            {
                return;
            }
        }

        WinChanged?.Invoke();
    }
}
