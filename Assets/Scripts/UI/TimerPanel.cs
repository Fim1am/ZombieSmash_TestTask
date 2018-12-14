using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;

    [SerializeField]
    private Text timerText;


    public void StartGame()
    {
        StartCoroutine(StartingGame());
    }

    public void IncrementLevel(System.Action _callback)
    {
        StartCoroutine(IncrementingLevel(_callback));
    }

    private IEnumerator StartingGame()
    {
        int t = gameSettings.timeBetweenLevels;

        while (t > 1)
        {
            t -= 1;
            timerText.text = t.ToString();

            yield return new WaitForSeconds(0.75f);
        }

        GameManager.Instance.StartGame();

        gameObject.SetActive(false);
    }

    private IEnumerator IncrementingLevel(System.Action _callback)
    {
        int t = gameSettings.timeBetweenLevels;

        while (t > 0)
        {
            t -= 1;

            timerText.text = t.ToString();

            yield return new WaitForSeconds(0.75f);
        }

        _callback.Invoke();

        gameObject.SetActive(false);

    }
}
