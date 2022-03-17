using System;
using UnityEngine;

[Serializable]
public class PencilConfig
{
    [SerializeField] private Line _template;
    [SerializeField] private DrawingBoard _drawingBoard;
    [SerializeField] private float _scale;
    [SerializeField] private float _minLineStepLength = 0.01f;

    public Line Template => _template;
    public DrawingBoard DrawingBoard => _drawingBoard;
    public float Scale => _scale;
    public float MinLineStepLength => _minLineStepLength;
}
