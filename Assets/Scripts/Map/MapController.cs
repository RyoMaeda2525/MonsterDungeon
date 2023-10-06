using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = default;

    [SerializeField]
    private TileScriptableObject _tileData;

    private int _rows = 0;

    private int _columns = 0;

    private GameObject[,] _objectsMap = null;

    private Vector2 _startTile = Vector2.zero;

    private Vector2 _goalTile = Vector2.zero;

    //‚±‚±‚ðŒã‚Åƒ^ƒCƒ‹‚Ìî•ñ‚ª“ü‚Á‚½‚à‚Ì‚É‚·‚é
    public string[,] Map => tileStates;

    public GameObject[,] ObjectsMap => _objectsMap;
    public Vector2 StartTile => _startTile;
    public Vector2 GoalTile => _goalTile;

    string[,] tileStates = new string[11, 11]
        {
            { "w", "w" , "w" , "w" , "w" , "s" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "n" , "n" , "n" , "n" , "n" , "n" , "n" , "n" , "n" , "w" },
            { "w", "w" , "w" , "n" , "n" , "n" , "n" , "n" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "n" , "w" , "w" , "w" , "w" , "w" },
            { "w", "w" , "w" , "w" , "w" , "g" , "w" , "w" , "w" , "w" , "w" },
        };

    void Awake()
    {
        _rows = tileStates.GetLength(0);
        _columns = tileStates.GetLength(1);
        MapGenerate();
    }

    private void MapGenerate()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        _objectsMap = new GameObject[_rows, _columns];

        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                var tileprefab = _tileData.TileList.Single(t => t.head == tileStates[r, c]).prefab;

                var tile = Instantiate(tileprefab, _gridLayoutGroup.transform);
                _objectsMap[r, c] = tile;

                if(tileStates[r , c] == "s") { _startTile = new Vector2(r, c); }
                if(tileStates[r , c] == "g") { _goalTile = new Vector2(r, c); }
            }
        }
    }
}
