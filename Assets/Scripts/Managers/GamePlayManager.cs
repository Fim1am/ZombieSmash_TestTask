using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GamePlayManager : MonoBehaviour
{
    public event Action<int> OnRemainTimeChanged, OnBombsChanged, OnZombieChanged;

    public GameSettings gameSettings;

    [SerializeField]
    private GamePanel gamePanel;

    [SerializeField]
    private UnitSpawner unitSpawner;

    [SerializeField]
    private UnitAnnihilator unitAnnihilator;

    [SerializeField]
    private TimerPanel timerPanel;
   
    public int currentLevel { get; private set; }

    private int remainTime, bombsCount, zombieToGameover;

    public int BombsCount => bombsCount;

    private void Start()
    {
        GetComponent<GameManager>().OnGameOver += () =>
        {
            StopCoroutine("TimeExpiration");
        };

        UnitAnnihilator.OnZombiePassed += ZombiePassed;

        BombsController.OnBombExplode += UsedBomb;

        gamePanel.InitPanel(this);       
    }

    public void InitLevel(int _level)
    {
        currentLevel = _level;

        remainTime = gameSettings.levelDuration;
        bombsCount = gameSettings.bombsOnLevel;
        zombieToGameover = gameSettings.gameoverZombies;

        gamePanel.SetLeftTime(remainTime);
        gamePanel.SetLeftBombs(bombsCount);
        gamePanel.SetLeftZombies(zombieToGameover);
        gamePanel.gameObject.SetActive(true);

        unitSpawner.gameObject.SetActive(true);

        StartCoroutine(gamePanel.ShowLevelInfo(currentLevel));
        StartCoroutine("TimeExpiration");
    }

    private void IncrementLevel()
    {
        unitSpawner.DestroyAllUnits();

        currentLevel++;

        InitLevel(currentLevel);
    }

    private IEnumerator TimeExpiration()
    {
        while(remainTime > 0)
        {
            remainTime -= 1;

            OnRemainTimeChanged.Invoke(remainTime);

            yield return new WaitForSecondsRealtime(1);
        }

        unitSpawner.gameObject.SetActive(false);
        unitSpawner.DestroyAllUnits();

        timerPanel.gameObject.SetActive(true);
        timerPanel.IncrementLevel(IncrementLevel);
    }

    private void ZombiePassed()
    {
        zombieToGameover--;

        OnZombieChanged?.Invoke(zombieToGameover);

        if (zombieToGameover < 1)
        {
            StopCoroutine("TimeExpiration");
            GameManager.Instance.GameOver();
        }
    }

    private void UsedBomb()
    {
        bombsCount--;

        OnBombsChanged?.Invoke(bombsCount);
    }

    public float GetSpawnModifier()
    {
        return (float)currentLevel * gameSettings.spawnTimeReduction;
    }

	public float GetSpeedModifier()
    {
        return (float)currentLevel * gameSettings.speedBoostPerLevel;
    }

}
