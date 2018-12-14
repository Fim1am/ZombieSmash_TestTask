using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event System.Action OnGameOver;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        GetComponent<GamePlayManager>().InitLevel(1);
    }

}
