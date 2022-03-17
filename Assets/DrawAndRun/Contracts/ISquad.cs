using System.Collections.Generic;
using UnityEngine;

public interface ISquad
{
    public IReadOnlyList<ICharacter> Characters { get; }

    void Create();
    void Add(ICharacter character);
    void MoveTo(List<Vector3> positions);
}
