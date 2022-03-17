using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private bool _isGhost;

    private bool IsGhost => _isGhost;

    private void Awake()
    {
        if (_isGhost)
            ChangeColor(Color.gray);
        else
            ChangeColor(Color.green);
    }

    public void Move(Vector3 position)
    {
        _movement.Move(position);
    }

    private void ChangeColor(Color color)
    {
        _meshRenderer.SetProperty("_Color", color);
    }
}
