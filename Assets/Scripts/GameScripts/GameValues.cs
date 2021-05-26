using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameValues : MonoBehaviour
{
    [SerializeField] private AudioSource audioHeart = null;
    [SerializeField] private AudioClip[] audioClipHearts = null;
    [SerializeField] private WindowController windowController = null;
    [SerializeField] private GameObject[] hearts = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text scoreText = null;
    private float time = 0;
    public int scoreWin = 10;
    private int scoreNow = 0;
    private int hp = 3;

    public void StartGame()
    {
        StartCoroutine(SetTime());
        SetScore(0);
    }

    public void LoseHeart()
    {
        hp -= 1;
        audioHeart.clip = audioClipHearts[hp];
        audioHeart.Play();
        hearts[hp].SetActive(false);
        if (hp == 0)
            windowController.GameOver();
    }

    private void ResetHeart()
    {
        foreach (var heart in hearts)
        {
            heart.SetActive(true);
        }
    }

    private IEnumerator SetTime()
    {
        while (true)
        {
            time += Time.deltaTime;
            timeText.text = $"{(int)(time / 60)}:{(int)(time % 60)}";
            yield return null;
        }
    }

    public void SetScore(int points)
    {
        scoreNow += points;
        scoreText.text = $"{scoreNow}/{scoreWin}";
        if (scoreWin <= scoreNow)
            windowController.WinGame(hp);
    }

    public void ResetGame()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
        time = 0;
        hp = 3;
        scoreNow = 0;
        scoreText.text = $"{scoreNow}/{scoreWin}";
        ResetHeart();
        windowController.ResetGame();
    }
}
