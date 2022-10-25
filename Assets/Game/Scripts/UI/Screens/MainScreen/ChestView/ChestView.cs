using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Button _chestButton;
    [SerializeField] private Transform _chestIconTransform;

    private bool _isButtonActive;
    public void Show()
    {
        SetButtonActivation();
        SetButtonInteractable();
        ChestAnimation();
    }

    public void Hide()
    {
        DOTween.KillAll();
    }

    public void GiveTreasure()
    {

    }

    private void SetButtonActivation()
    {
        if (PlayerHelper.Instance.Player.Level % 3 == 0)
            _isButtonActive = true;
        else
            _isButtonActive = false;
    }

    private void SetButtonInteractable()
    {
        _chestButton.interactable = _isButtonActive;
    }
    
    private void ChestAnimation()
    {
        if (!_isButtonActive)
            return;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_chestIconTransform.DOScale(1.2f, .2f))
                .Append(_chestIconTransform.DOScale(1f, .2f))
                .SetLoops(-1);
    }
}
