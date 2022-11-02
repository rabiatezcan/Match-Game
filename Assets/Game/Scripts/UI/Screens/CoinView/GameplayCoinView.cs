using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCoinView : CoinView
{
    public Action OnCoinAnimationCompleted;

    [SerializeField] private List<CoinImage> _coinImages;
    [SerializeField] private Transform _panTransform;
    [SerializeField] private Transform _totalCoinImageTransform;

    public override void SetCoinText()
    {
        _coinText.text = (PlayerHelper.Instance.Player.Coin + ScoreSystem.GetCurrentScore()).ToString();
    }
    public void Initialize()
    {
        _coinImages.ForEach(image => image.Hide());
    }
    public void CoinAnimation()
    {
        StartCoroutine(CoinAnimationCoroutine());
    }

    private IEnumerator CoinAnimationCoroutine()
    {
        int index = 0;
        while (index < _coinImages.Count)
        {
            yield return new WaitForSeconds(.25f);
            _coinImages[index].SetMovePosition(_totalCoinImageTransform.position);
            index++;
        }
        yield return new WaitForSeconds(.75f);
        OnCoinAnimationCompleted?.Invoke();
    }

  

}
