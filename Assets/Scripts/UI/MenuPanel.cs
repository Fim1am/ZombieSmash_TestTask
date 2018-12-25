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
    private TimeController timeController;

    public void PlayButton()
    {
        timeController.StartGame();
        gameObject.SetActive(false);
    }

	
}
