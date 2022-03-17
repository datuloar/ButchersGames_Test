using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : MonoBehaviour, IViewport
{
    [SerializeField] private PlayGameWindow _playGameWindow;

    public IPlayGameWindow GetPlayGameWindow() => _playGameWindow;
}
