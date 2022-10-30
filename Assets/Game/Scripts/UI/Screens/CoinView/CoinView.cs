using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    public void SetCoinText()
    {
        _coinText.text = PlayerHelper.Instance.Player.Coin.ToString();
    }

}
