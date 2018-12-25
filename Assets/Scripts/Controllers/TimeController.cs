using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private TimerPanel timerPanel;

    private GamePlayManager playManager;
	
	void Start ()
    {
        playManager = FindObjectOfType<GamePlayManager>();

        timerPanel.gameObject.SetActive(false);
	}

    public void IncrementLevel(System.Action _callback)
    {
        StartCoroutine(IncrementingLevel(_callback));
    }

    public void StartGame()
    {
        StartCoroutine(StartingGame());
    }

    private IEnumerator StartingGame()
    {
        int t = playManager.gameSettings.timeBetweenLevels;
        timerPanel.gameObject.SetActive(true);

        while (t > 1)
        {
            t -= 1;

            timerPanel.SetTimerText(t);

            yield return new WaitForSeconds(0.75f);
        }

        GameManager.Instance.StartGame();

        timerPanel.gameObject.SetActive(false);
    }

    private IEnumerator IncrementingLevel(System.Action _callback)
    {
        int t = playManager.gameSettings.timeBetweenLevels;
        timerPanel.gameObject.SetActive(true);

        while (t > 0)
        {
            t -= 1;

            timerPanel.SetTimerText(t);

            yield return new WaitForSeconds(0.75f);
        }

        _callback.Invoke();

        timerPanel.gameObject.SetActive(false);

    }
}
