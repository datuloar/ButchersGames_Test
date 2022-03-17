using UnityEngine;

public interface ILine
{
    int PositionCount { get; }

    void NextPosition();
}