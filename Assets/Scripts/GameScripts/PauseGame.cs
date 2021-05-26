using UnityEngine;

public class PauseGame : Window
{
    public void Pause()
    {
        GameManager.isGame = false;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        GameManager.isGame = true;
        Time.timeScale = 1;
    }
}
