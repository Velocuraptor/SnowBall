using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioHeart = null;
    [SerializeField] private AudioClip[] audioClipHearts = null;
    [SerializeField] private Editor editor = null;
    [SerializeField] private Hippo hippo = null;
    [SerializeField] private GameObject menuUI = null, gameUI = null; 
    [SerializeField] private WinGame winWindow = null;
    [SerializeField] private LoseGame loseWindow = null;
    [SerializeField] private PauseGame pauseWindow = null;
    [SerializeField] private EnemyController enemySpawner = null;
    [SerializeField] private GameObject[] hearts = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private SnowballButton snowballButton = null;
    private Window activeWindow = null;
    public int scoreWin = 10;
    private int scoreNow = 0;
    private int HP = 3;
    public static bool isGame { set; get; } = false;
    private float time = 0;

    private void Update()
    {
        if(isGame)
            SetTime();
    }

    public void LoseHeart()
    {
        HP -= 1;
        audioHeart.clip = audioClipHearts[HP];
        audioHeart.Play();
        hearts[HP].SetActive(false);
        if (HP == 0)
            GameOver();
    }

    public void ResetHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    private void SetTime()
    {
        time += Time.deltaTime;
        timeText.text = $"{(int)(time / 60)}:{(int)(time % 60)}";
    }

    public void SetScore(int points)
    {
        scoreNow += points;
        scoreText.text = $"{scoreNow}/{scoreWin}";
        if (scoreWin <= scoreNow)
            WinGame(HP);
    }

    public void StartGame()
    {
        SetScore(0);
        editor.SettingCharacteristics();
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        isGame = true;
        enemySpawner.StartGame();
    }

    private void GameOver()
    {
        loseWindow.OpenWindow();
        pauseWindow.Pause();
    }

    private void WinGame(int HP)
    {
        pauseWindow.Pause();
        winWindow.OpenWindow();
        winWindow.ActiveStar(HP);
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
        Time.timeScale = 1;
        time = 0;
        HP = 3;
        scoreNow = 0;
        scoreText.text = $"{scoreNow}/{scoreWin}";
        ResetHeart();
        winWindow.ResetStar();
        snowballButton.ResetButton();
        hippo.ResetGame();
        enemySpawner.ResetGame();
        activeWindow.CloseWindow();
    }

    public void SetActivateWindow(Window window)
    {
        activeWindow = window;
    }
}
