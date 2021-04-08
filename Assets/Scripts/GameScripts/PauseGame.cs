using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PauseGame : Window
{
    [SerializeField] private EnemySpawner enemySpawner = null;
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
