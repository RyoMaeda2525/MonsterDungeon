using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hero : MonoBehaviour
{
    [SerializeField]
    MapController _controller;

    private GameObject[,] _objectsMap = null;

    string[,] _map = null;

    int[,] _mapIndex = null;

    Queue<Tile> _queue = new Queue<Tile>();

    Tile _position;

    Tile _goalTile;

    Vector2[] _points = new Vector2[4] { //上下左右の順
        new Vector2 (0, 1), new Vector2 (0, -1), new Vector2 (-1, 0), new Vector2 (1, 0)
    };

    // Start is called before the first frame update
    void Start()
    {
        Map();

        _goalTile = _controller.GoalTile;
        _position = _controller.StartTile;

        Search();
    }

    private void Search()
    {
        Queue<Vector2> loads = new Queue<Vector2>();

        foreach (var point in _points)
        {
            Vector2 position = _position + point;

            int row = (int)position.x, col = (int)position.y;

            if (row > -1 && row < _map.GetLength(0) && col > -1 && col < _map.GetLength(1))

                if (_mapIndex[row, col] != 0)
                {
                    switch (_map[row, col])
                    {
                        case "w":
                            break;
                        case "n":
                        case "s":
                            if (_mapIndex[row, col] == -1) { _mapIndex[row, col] = 0; }
                            _mapIndex[(int)_position.x, (int)_position.y]++;
                            loads.Enqueue(position);
                            break;
                        case "g":
                            return;
                    }
                }
        }

        if (loads.Count > 0)
        {
            _queue.Enqueue(_position);
            _position = loads.Dequeue();
            _mapIndex[(int)_position.x, (int)_position.y]--;
        }
        else if (_queue.Count > 0)
        {
            _position = _queue.Dequeue();
        }
        else
        {
            Debug.Log("Game Over");
            return;
        }

        this.transform.position = _objectsMap[(int)_position.x, (int)_position.y].transform.position;
        Debug.Log($"マップでの位置:{_position} , 座標:{this.transform.position}");
        Search();
    }

    private void Map()
    {
        _objectsMap = _controller.ObjectsMap;
        _map = _controller.Map;
        _mapIndex = new int[_map.GetLength(0), _map.GetLength(1)];

        for (int r = 0; r < _map.GetLength(0); r++)
        {
            for (int c = 0; c < _map.GetLength(1); c++)
            {
                _mapIndex[r, c] = -1;
            }
        }
    }

    //private bool TileJudg(int row , int col) 
    //{
    //    switch (_map[row, col]) 
    //    {
    //        case "w":
    //            break;
    //        case "n":
    //            _mapIndex[row, col]++;
    //            break;
    //        case "s":
    //            break;
    //        case "g":
    //            return true;
    //    }
    //    return false;
    //}
}
