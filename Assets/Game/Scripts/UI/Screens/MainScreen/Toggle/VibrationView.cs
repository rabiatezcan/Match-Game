using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationView : MonoBehaviour
{
    [SerializeField] ToggleButton _toggleButton;

    public void Show()
    {
        _toggleButton.SetToggle(PlayerHelper.Instance.Player.IsVibrationOn, 0f);
    }

    public void SetVibration()
    {
        PlayerHelper.Instance.UpdateVibration(!PlayerHelper.Instance.Player.IsVibrationOn);
        _toggleButton.SetToggle(PlayerHelper.Instance.Player.IsVibrationOn, .2f);
    }
}
