using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] private WinGame winWindow = null;
    [SerializeField] private LoseGame loseWindow = null;
    [SerializeField] private PauseGame pauseWindow = null;
    private Window activeWindow = null;

    public void GameOver()
    {
        loseWindow.OpenWindow();
        pauseWindow.Pause();
    }

    public void WinGame(int hp)
    {
        pauseWindow.Pause();
        winWindow.OpenWindow();
        winWindow.ActiveStar(hp);
    }
    
    public void ResetGame()
    {
        winWindow.ResetStar();
        activeWindow.CloseWindow();
    }
    
    public void SetActivateWindow(Window window)
    {
        activeWindow = window;
    }
}
