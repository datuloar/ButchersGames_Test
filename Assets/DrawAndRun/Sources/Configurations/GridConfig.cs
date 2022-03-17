using System;
using UnityEngine;

[Serializable]
public class GridConfig
{
    [SerializeField] private int _rows;
    [SerializeField] private int _cols;
    [SerializeField] private float _distanceBetweenElements;
    [SerializeField] private float _xOffset;

    public int Rows => _rows;
    public int Cols => _cols;
    public float DistanceBetweenElements => _distanceBetweenElements;
    public float XOffset => _xOffset;
    public int Count => _rows * _cols;
}
