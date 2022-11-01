using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    [SerializeField] protected Text _coinText;
    public virtual void SetCoinText()
    {
        _coinText.text = PlayerHelper.Instance.Player.Coin.ToString();
    }

}
