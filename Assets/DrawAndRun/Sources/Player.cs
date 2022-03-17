using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IUpdateLoop
{
    private readonly IPencil _pencil;
    private readonly ISquad _squad;
    private readonly IInputCamera _inputCamera;

    public Player(IPencil pencil, ISquad squad, IInputCamera inputCamera)
    {
        _pencil = pencil;
        _squad = squad;
        _inputCamera = inputCamera;
    }

    public void Tick(float time)
    {
        if (Input.GetMouseButtonDown(0))
            _pencil.CreateLine(GetTouchPosition());

        if (Input.GetMouseButton(0))
            _pencil.Draw(GetTouchPosition());

        if (Input.GetMouseButtonUp(0))
        {
            var drawPointPositions = _pencil.GetFixedDrawPointPositions();
            _squad.MoveTo(drawPointPositions);
            _pencil.EndDraw();
        }
    }

    private Vector3 GetTouchPosition()
    {
        Ray ray = _inputCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            if (hit.collider.TryGetComponent(out IDrawingBoard drawingBoard))
                return hit.point;

        return Vector3.zero;
    }

    public void CreateSquad() => _squad.Create();
}
