using System.Collections.Generic;
using UnityEngine;

public interface IPencil
{
    void CreateLine(Vector3 position);
    void Draw(Vector3 position);
    void EndDraw();
    List<Vector3> GetFixedDrawPointPositions();
}