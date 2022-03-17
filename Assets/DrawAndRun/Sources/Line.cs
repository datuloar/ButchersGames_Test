using UnityEngine;

public class Line : MonoBehaviour, ILine
{
    [SerializeField] private LineRenderer _lineRenderer;

    public int PositionCount => _lineRenderer.positionCount;

    public void SetPosition(int index, Vector3 position)
    {
        _lineRenderer.SetPosition(index, position);
    }

    public void NextPosition() => _lineRenderer.positionCount++;
}
