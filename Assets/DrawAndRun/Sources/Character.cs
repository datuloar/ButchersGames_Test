using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterMovement _movement;

    public void Move(Vector3 position)
    {
        _movement.Move(position);
    }
}
