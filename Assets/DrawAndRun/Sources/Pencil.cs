using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : IPencil
{
    private readonly Line _template;
    private readonly DrawingBoard _drawingBoard;
    private readonly float _minLineStepLength;
    private readonly float _scale;

    private Line _currentLine;
    private List<Vector3> _touchPositions = new List<Vector3>();

    public Pencil(PencilConfig config)
    {
        _template = config.Template;
        _drawingBoard = config.DrawingBoard;
        _minLineStepLength = config.MinLineStepLength;
        _scale = config.Scale;
    }

    public void CreateLine(Vector3 position)
    {
        if (position == Vector3.zero)
            return;

        _currentLine = Object.Instantiate(_template, _drawingBoard.transform);
        _currentLine.SetPosition(0, position);
        _touchPositions.Add(position);
    }

    public void Draw(Vector3 position)
    {
        if (position == Vector3.zero)
            return;

        if (Vector2.Distance(position, _touchPositions[_touchPositions.Count - 1]) > _minLineStepLength)
        {
            _touchPositions.Add(position);
            _currentLine.NextPosition();
            _currentLine.SetPosition(_currentLine.PositionCount - 1, position);
        }
    }

    public void EndDraw()
    {
        Clear();
    }

    public List<Vector3> GetFixedDrawPointPositions()
    {
        var positions = new List<Vector3>();

        for (int i = 0; i < _touchPositions.Count; i++)
        {
            var fixedTouchPosition =_touchPositions[i] - _drawingBoard.transform.position;
            var zPosition = fixedTouchPosition.y + fixedTouchPosition.y * Mathf.Cos(
                _drawingBoard.transform.eulerAngles.x) * _scale;

            var currentPosition = new Vector3(fixedTouchPosition.x * _scale, 0, zPosition);
            positions.Add(currentPosition);
        }

        return positions;
    }

    private void Clear()
    {
        if (_currentLine == null)
            return;

        _touchPositions.Clear();
        Object.Destroy(_currentLine.gameObject);
        _currentLine = null;
    }
}
