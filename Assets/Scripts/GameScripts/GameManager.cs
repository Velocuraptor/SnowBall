using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Editor editor = null;
    [SerializeField] private Hippo hippo = null;
    [SerializeField] private GameObject menuUI = null;
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private EnemyController enemySpawner = null;
    [SerializeField] private SnowballButton snowballButton = null;
    [SerializeField] private GameValues gameValues = null;
    public static bool isGame = false;

    

    public void StartGame()
    {
        gameValues.StartGame();
        editor.SettingCharacteristics();
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        isGame = true;
        enemySpawner.StartGame();
    }
    
    public void RestartGame()
    {
        ResetGame();
        StartGame();
    }

    public void MenuGame()
    {
        ResetGame();
        menuUI.SetActive(true);
        gameUI.SetActive(false);
    }

    private void ResetGame()
    {
        gameValues.ResetGame();
        snowballButton.ResetButton();
        hippo.ResetGame();
        enemySpawner.ResetGame();
    }
}
