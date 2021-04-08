using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private AudioSource audioThrow = null;
    public float timeReload = 5.0f;
    public SpawnPosition[] spawnPositions = null;

    public void StartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnPositions[i].CreateEnemy();
        }
        StartCoroutine(TimeDelay());
    }

    private IEnumerator TimeDelay()
    {
        float delay = timeReload;
        while (0 < delay)
        {
            delay -= Time.deltaTime;
            yield return null;    
        }
        ChooseEnemyThrow();
    }

    private void ChooseEnemyThrow()
    {
        spawnPositions[Random.Range(0, 3)].enemyActive.Throw();
        audioThrow.Play();
        StartCoroutine(TimeDelay());
    }

    public void ResetGame()
    {
        StopAllCoroutines();
        foreach (var spawnPosition in spawnPositions)
        {
            spawnPosition.ResetPosition();
        }
    }
}
