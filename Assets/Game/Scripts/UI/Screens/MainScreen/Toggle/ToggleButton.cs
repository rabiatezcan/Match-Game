using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Transform _switchTransform;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private float _toggleXAxisPosition;

    [SerializeField] private Color _onButtonColor;
    [SerializeField] private Color _offButtonColor;
    [SerializeField] private Color _onBackgroundColor;
    [SerializeField] private Color _offBackgroundColor;
    public void SetToggle(bool isOn, float duration)
    {
        int xDirection = isOn ? 1 : -1;
        SetTogglePosition(xDirection, duration);
        SetToggleColors(isOn, duration);
    }
    private void SetTogglePosition(int multiplier, float duration)
    {
        _switchTransform.DOLocalMoveX(_toggleXAxisPosition * multiplier, duration);
    }

    private void SetToggleColors(bool isOn, float duration)
    {
        if (isOn)
        {
            _buttonImage.DOColor(_onButtonColor, duration);
            _backgroundImage.DOColor(_onBackgroundColor, duration);
        }
        else
        {
            _buttonImage.DOColor(_offButtonColor, duration);
            _backgroundImage.DOColor(_offBackgroundColor, duration);
        }
    }
}
