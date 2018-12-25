using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : MonoBehaviour
{

    [SerializeField]
    private Text timerText;

    public void SetTimerText(int _val)
    {
        timerText.text = _val.ToString();
    }

}
