using System;
using UnityEngine;

[Serializable]
public class SquadConfig
{
    [SerializeField] private Character _template;
    [SerializeField] private SquadContainer _container;
    [SerializeField] private GridConfig _gridConfig;

    public Character Template => _template;
    public SquadContainer Container => _container;
    public GridConfig Grid => _gridConfig;
    public int CharactersCount => _gridConfig.Cols * _gridConfig.Rows;
}
