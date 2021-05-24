using UnityEngine;

public class PauseGame : Window
{
    [SerializeField] private EnemyController enemySpawner = null;
    [SerializeField] private SnowballButton snowballButton = null;

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
