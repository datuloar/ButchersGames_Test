using System;
using System.Collections.Generic;
using UnityEngine;

public class Grid : IGrid
{
    private readonly int _rows;
    private readonly int _cols;
    private readonly int _count;
    private readonly float _offset;

    private Queue<Vector2> _cellsQueue;

    public Grid(GridConfig settings)
    {
        _rows = settings.Rows;
        _cols = settings.Cols;
        _count = settings.Count;
        _offset = settings.Offset;
    }

    public void Create()
    {
        var cellsPosition = new Vector2[_count];
        float width = _cols * _offset;
        float height = _rows * _offset;

        for (int y = 0, offset = 0; y < _rows; y++, offset += _cols)
        {
            for (int x = 0; x < _cols; x++)
            {
                cellsPosition[offset + x] = new Vector2(
                       x * _offset - width / _cols,
                       y * _offset + height / _rows - _rows);
            }
        }

        _cellsQueue = new Queue<Vector2>(cellsPosition);
    }

    public void Add(ICharacter character)
    {
        if (_cellsQueue == null)
            throw new Exception("Сreate grid before insert");

        var cell = _cellsQueue.Dequeue();
        var newPosition = new Vector3(cell.x, character.transform.position.y, cell.y);

        character.transform.localPosition = newPosition;
    }
}
