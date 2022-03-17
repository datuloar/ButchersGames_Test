using System.Collections.Generic;
using UnityEngine;

public class Squad : ISquad
{
    private readonly Character _template;
    private readonly SquadContainer _container;
    private readonly int _charactersCount;
    private readonly IGrid _grid;

    private List<ICharacter> _characters;

    public Squad(SquadConfig config)
    {
        _template = config.Template;
        _container = config.Container;
        _charactersCount = config.CharactersCount;

        _grid = new Grid(config.Grid);
    }

    public IReadOnlyList<ICharacter> Characters => _characters;

    public void Create()
    {
        _characters = new List<ICharacter>();
        _grid.Create();

        for (int i = 0; i < _charactersCount; i++)
        {
            var character = Object.Instantiate(_template, _container.transform);
            Add(character);
        }
    }

    public void MoveTo(List<Vector3> linePositions)
    {
        var movePositions = ConvertLinePositionToMove(linePositions);

        for (int i = 0; i < movePositions.Count; i++)
            _characters[i].Move(movePositions[i]);
    }

    public void Add(ICharacter character)
    {
        if (_characters == null)
            throw new System.NullReferenceException("Create Squad before add");

        _grid.Add(character);
        _characters.Add(character);
    }

    private List<Vector3> ConvertLinePositionToMove(List<Vector3> linePositions)
    {
        var movePositions = new List<Vector3>();

        if (linePositions.Count <= 0)
            return movePositions;

        if (linePositions.Count >= _characters.Count)
        {
            int spacing = linePositions.Count / _characters.Count;

            for (int i = 0; i < _characters.Count; i++)
                movePositions.Add(new Vector3(linePositions[i * spacing].x, 0, linePositions[i * spacing].z));
        }
        else
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                if (i < linePositions.Count)
                    movePositions.Add(linePositions[i]);
                else
                    movePositions.Add(linePositions[linePositions.Count - 1]);
            }
        }

        return movePositions;
    }
}
