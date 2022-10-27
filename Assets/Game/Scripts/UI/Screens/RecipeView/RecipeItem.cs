using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeItem : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _amountTxt;

    public void Initialize(Sprite icon, int amount)
    {
        SetSprite(icon);
        SetText(amount);
    }

    private void SetSprite(Sprite icon)
    {
        _icon.sprite = icon;
    }
    private void SetText(int amount)
    {
        _amountTxt.text = "x" + amount;
    }
}
