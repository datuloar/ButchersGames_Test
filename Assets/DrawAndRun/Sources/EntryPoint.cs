using System.Collections;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private MainCamera _mainCamera;
    [SerializeField] private InputCamera _inputCamera;

    [Header("Viewport")]
    [SerializeField] private Viewport _viewport;

    [Header("Configurations")]
    [SerializeField] private SquadConfig _squadConfig;
    [SerializeField] private PencilConfig _pencilConfig;

    private Game _game;

    private void Awake()
    {
        var squad = new Squad(_squadConfig);
        var pencil = new Pencil(_pencilConfig);
        var player = new Player(pencil, squad, _inputCamera);

        _game = new Game(player, _viewport);
        _mainCamera.SetTarget(_squadConfig.Container);
    }

    private void Start()
    {
        _game.Start();
    }

    private void Update()
    {
        _game.Tick(Time.deltaTime);
    }

    private void OnApplicationQuit()
    {
        _game.End();
    }
}
