using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public Action<float> OnTimeChanged;

    private LevelController _levelController;
    private float _currentTime;
    private bool _canTimerWork;

    #region Core
    public void Initialize(LevelController levelController)
    {
        _levelController = levelController;
    }

    public void StartGame()
    {
        _currentTime = _levelController.CurrentLevel.LevelTimeForSecond;

        _canTimerWork = true;
    }
    public void GameOver()
    {
        _canTimerWork = false;
    }

    #endregion

    private void DecreaseTime()
    {
        _currentTime -= Time.deltaTime;
        OnTimeChanged?.Invoke(_currentTime);
    }
    private void CheckTimer()
    {
        if (_currentTime <= 0f)
            GameManager.Instance.GameFail();
    }

    private void Update()
    {
        if (_canTimerWork)
        {
            DecreaseTime();
            CheckTimer();
        }
    }





}
