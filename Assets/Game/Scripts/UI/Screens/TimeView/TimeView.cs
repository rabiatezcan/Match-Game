using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField] private Text _timeTxt;
    [SerializeField] private TimeHandler _timeHandler;

    private int _minute;
    private int _second;

    public void Show()
    {
        _timeHandler.OnTimeChanged += UpdateTime;
    }

    public void Hide()
    {
        _timeHandler.OnTimeChanged -= UpdateTime;
    }

    public void UpdateTime(float time)
    {
        SecondToMinute(time);
        SetTimeText();
    }
    private void SecondToMinute(float time)
    {
        _second = (int)(time % 60f);
        _minute = (int)(time / 60f);
    }
    private void SetTimeText()
    {
        _timeTxt.text = _minute + " : " + _second;
    }
}
