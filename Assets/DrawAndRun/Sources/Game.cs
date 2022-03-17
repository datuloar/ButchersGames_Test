public class Game : IGame, IUpdateLoop
{
    private readonly Player _player;
    private readonly IViewport _viewport;

    public Game(Player player, IViewport viewport)
    {
        _player = player;
        _viewport = viewport;
    }

    public void Start()
    {
        _viewport.GetPlayGameWindow().Open();

        _player.CreateSquad();
    }

    public void Tick(float time)
    {
        _player.Tick(time);
    }

    public void End()
    {
        
    }
}
