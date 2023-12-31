using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TileScriptableObject : ScriptableObject
{
    [SerializeField]
    List<TileData> _tileList = new List<TileData>();

    public List<TileData> TileList => _tileList;
}

[Serializable]
public class TileData
{
    public string head;
    public GameObject prefab;
    public Head enumHead; //enumで問題ないならheadはいらない
}

public enum Head   
{
    w,
    s,
    n,
    g,
}
