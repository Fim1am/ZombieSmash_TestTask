using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{

    private float timeToStart = 4f;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private TimerPanel timerPanel;

    private void OnEnable()
    {
        timerPanel.gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        timerPanel.gameObject.SetActive(true);
        timerPanel.StartGame();
        gameObject.SetActive(false);
    }

	
}
