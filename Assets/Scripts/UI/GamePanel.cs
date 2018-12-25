using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Text bombsText, timerText, zombiesText, levelText;

    [SerializeField]
    private Button bombsButton;

    [SerializeField]
    private GameObject gameoverPanel, levelPanel, menuPanel;

    [SerializeField]
    private TimeController timeController;

    private GamePlayManager currentGameplay;

    private void OnEnable()
    {
        gameoverPanel.SetActive(false);
    }

    public void InitPanel(GamePlayManager _gameplay)
    {
        currentGameplay = _gameplay;

        GameManager.Instance.OnGameOver += ShowGameoverPanel;

        _gameplay.OnBombsChanged += SetLeftBombs;
        _gameplay.OnRemainTimeChanged += SetLeftTime;
        _gameplay.OnZombieChanged += SetLeftZombies;
    }

    public IEnumerator ShowLevelInfo(int _currLevel)
    {
        levelText.text = "level " + _currLevel;

        levelPanel.SetActive(true);

        Color textCol = Color.white;

        levelText.color = textCol;

        float duration = 1f;

        while(duration > 0)
        {
            duration -= Time.deltaTime;

            textCol.a = duration;

            levelText.color = textCol;

            yield return new WaitForEndOfFrame();
        }

        levelPanel.SetActive(false);
    }

    private void ShowGameoverPanel()
    {
        gameoverPanel.SetActive(true);
    }
    
    public void TryAgainButton()
    {
        timeController.StartGame();
        gameoverPanel.SetActive(false);
    }

    public void ToMenuButton()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetLeftZombies(int _count)
    {
        zombiesText.text = _count.ToString();
    }

    public void SetLeftBombs(int _count)
    {

        if (_count < 1)
        {
            bombsButton.interactable = false;
            bombsText.text = "0";
        }
        else
        {
            bombsButton.interactable = true;
            bombsText.text = _count.ToString();
        }
    }

    public void SetLeftTime(int _time)
    {

        int mins = _time / 60;

        _time -= mins * 60;

        int seconds = _time;

        timerText.text = mins.ToString("00") +  " : " + seconds.ToString("00");
    }
}
