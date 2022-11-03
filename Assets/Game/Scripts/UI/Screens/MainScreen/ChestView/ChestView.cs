using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Button _chestButton;
    [SerializeField] private Transform _chestIconTransform;
    [SerializeField] private Transform _treasureTransform;
    public void Show()
    {
        SetButtonActivation();
        ChestAnimation();
    }

    public void Hide()
    {
        DOTween.KillAll();
    }

    public void GiveTreasure()
    {
        DOTween.KillAll();
        SetButtonInteractable(false);
        TreasureAnimation();
        PlayerHelper.Instance.UpdateCoin(CONSTANTS.TREASURE_COIN_AMOUNT);
    }

    private void SetButtonActivation()
    {
        if (PlayerHelper.Instance.Player.Level % 3 == 0)
            SetButtonInteractable(true);
        else
            SetButtonInteractable(false);
    }

    private void SetButtonInteractable(bool isActive)
    {
        _chestButton.interactable = isActive;
    }
    
    private void ChestAnimation()
    {
        if (!_chestButton.IsInteractable())
            return;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_chestIconTransform.DOScale(1.2f, .3f))
                .Append(_chestIconTransform.DOScale(1f, .3f))
                .SetLoops(-1);
    }

    private void TreasureAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_treasureTransform.DOScale(1f, .2f))
                .Append(_treasureTransform.DOScale(0f, .4f).SetDelay(.5f));
    }
}
