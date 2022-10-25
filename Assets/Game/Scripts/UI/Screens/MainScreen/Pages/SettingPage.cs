using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPage : Page
{
    [SerializeField] private SoundView _soundView;   
    [SerializeField] private VibrationView _vibrationView;

    public override void Show()
    {
        _soundView.Show();
        _vibrationView.Show();
        base.Show();
    }
}
