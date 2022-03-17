using System;
using UnityEngine;

[Serializable]
public class GridConfig
{
    [SerializeField] private int _rows;
    [SerializeField] private int _cols;
    [SerializeField] private float _offset;

    public int Rows => _rows;
    public int Cols => _cols;
    public float Offset => _offset;
    public int Count => _rows * _cols;
}
