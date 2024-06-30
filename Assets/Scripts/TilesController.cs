using System;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    [SerializeField] private Transform _tileEmpty = null;
    [SerializeField] private int _gridSize = 4;
    [SerializeField] private TilesMovement[] _tiles;

    [SerializeField] private GameObject _panel;

    private TilesMovement[] _solution;
    private int[,] _tilesInt;
    private Camera _camera;

    private bool _isStart;

    private void Awake()
    {
        _tilesInt = new int[_gridSize, _gridSize];
        _solution = new TilesMovement[_tiles.Length];
        _camera = Camera.main;

        for (int i = 0; i < _tiles.Length; i++)
        {
            _solution[i] = _tiles[i];
        }

        ArrayUpdate();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CheckIfSolved();
        }
    }

    public void Shuffle()
    {
        var passer = new System.Random();

        for (int j = 0; j < 600; j++)
        {
            for (int i = 0; i < _tiles.Length; i++)
            {
                if (_tiles[i] != null && Vector2.Distance(_tileEmpty.position, _tiles[i].TargetPos) <= 7)
                {
                    if (passer.Next(2) == 1)
                    {
                        Vector2 lastEmptySpacePos = _tileEmpty.position;
                        _tileEmpty.position = _tiles[i].TargetPos;
                        _tiles[i].InitTarget(lastEmptySpacePos);
                        _tiles[FindNull()] = _tiles[i];
                        _tiles[i] = null;
                        break;
                    }
                }
            }
        }

        _isStart = true;
    }

    private void Move()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit)
        {
            if (Vector2.Distance(_tileEmpty.position, hit.transform.position) <= 7)
            {
                Vector2 lastEmptySpacePos = _tileEmpty.position;
                TilesMovement current = hit.transform.GetComponent<TilesMovement>();
                var index = FindIn(current);
                _tileEmpty.position = current.TargetPos;
                current.InitTarget(lastEmptySpacePos);
                _tiles[FindNull()] = current;
                _tiles[index] = null;
            }
        }
    }

    private int FindNull()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            if (_tiles[i] is null)
                return i;
        }

        throw new Exception("Empty tiles has not been found!");
    }

    private int FindIn(TilesMovement search)
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            if (_tiles[i] != null && _tiles[i].Equals(search))
                return i;
        }

        throw new Exception("ERROR! Element is not included in the array!");
    }

    private void ArrayUpdate()
    {
        int tileCount = 0;

        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                if (tileCount < _tiles.Length && _tiles[tileCount] != null)
                {
                    _tilesInt[i, j] = _tiles[tileCount].Key;
                }
                else
                {
                    _tilesInt[i, j] = 0;
                }
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

        _panel.SetActive(true);
        Debug.Log("Пазл собран правильно!");
        Time.timeScale = 0;
    }
}
