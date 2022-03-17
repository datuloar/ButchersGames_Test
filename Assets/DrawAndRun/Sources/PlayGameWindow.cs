using UnityEngine;

public class PlayGameWindow : MonoBehaviour, IPlayGameWindow
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Close() => _canvasGroup.Close();

    public void Open() => _canvasGroup.Open();
}
