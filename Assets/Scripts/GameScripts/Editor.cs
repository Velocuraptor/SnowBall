using System;
using UnityEngine;
using UnityEngine.UI;

public class Editor : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies = null;
    [SerializeField] private Hippo hippo = null;
    [SerializeField] private GameValues gameValues = null;
    [SerializeField] private EnemyController enemySpawner = null;
    [SerializeField] private SnowballButton snowballButton = null;

    [SerializeField] private InputField inputSpeedEnemy = null;
    [SerializeField] private InputField inputSpeedHippo = null;
    [SerializeField] private InputField inputScoreWin = null;
    [SerializeField] private InputField inputTimeReload = null;
    [SerializeField] private InputField inputTimeReloadEnemy = null;
    [SerializeField] private InputField[] inputEnemyPointsHits = null;

    private float standartSpeedEnemy;
    private float standartSpeedHippo;
    private float standartScoreWin;
    private float standartTimeReload;
    private float standartTimeReloadEnemy;
    private float[] standartEnemyPointsHit = new float[3];



    private void Awake()
    {
        standartSpeedEnemy = StartSettings(inputSpeedEnemy,enemies[0].speed);
        standartSpeedHippo = StartSettings(inputSpeedHippo, hippo.speed);
        standartScoreWin = StartSettings( inputScoreWin, gameValues.scoreWin);
        standartTimeReload = StartSettings(inputTimeReload, snowballButton.timeReaload);
        standartTimeReloadEnemy = StartSettings(inputTimeReloadEnemy, enemySpawner.timeReload);
        for (int i = 0; i < 3; i++)
            standartEnemyPointsHit[i] = StartSettings(inputEnemyPointsHits[i], enemies[i].points);

    }

    public void SettingCharacteristics()
    {
        for (int i = 0; i < 3; i++)
        {
            enemies[i].speed = CheckInputField(inputSpeedEnemy, standartSpeedEnemy);
            enemies[i].points = (int)CheckInputField(inputEnemyPointsHits[i], standartEnemyPointsHit[i]);
        }
        hippo.speed = CheckInputField(inputSpeedHippo, standartSpeedHippo);
        gameValues.scoreWin = (int)CheckInputField(inputScoreWin, standartScoreWin);
        snowballButton.timeReaload = CheckInputField(inputTimeReload, standartTimeReload);
        enemySpawner.timeReload = CheckInputField(inputTimeReloadEnemy, standartTimeReloadEnemy);

    }
    private float StartSettings(InputField input, float value)
    {
        input.placeholder.GetComponent<Text>().text = Convert.ToString(value);
        return value;
    }

    private float CheckInputField(InputField input, float standart)
    {
        string text = input.text;
        if (text != "")
        {
            return float.Parse(text);
        }
        return standart;
    }
}
