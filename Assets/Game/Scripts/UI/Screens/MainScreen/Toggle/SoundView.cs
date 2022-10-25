using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundView : MonoBehaviour
{
    [SerializeField] ToggleButton _toggleButton;

    public void Show()
    {
        _toggleButton.SetToggle(PlayerHelper.Instance.Player.IsSoundOn, 0f);
    }

    public void SetSound()
    {
        PlayerHelper.Instance.UpdateSound(!PlayerHelper.Instance.Player.IsSoundOn);
        _toggleButton.SetToggle(PlayerHelper.Instance.Player.IsSoundOn, .2f);
    }
}
