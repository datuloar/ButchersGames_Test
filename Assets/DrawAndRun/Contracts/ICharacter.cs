using UnityEngine;

public interface ICharacter
{
    Transform transform { get; }

    void Move(Vector3 position);
}
