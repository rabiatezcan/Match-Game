using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : Screen
{
    [SerializeField] private List<Page> _pages;
    [SerializeField] private CoinView _coinView;
    private void HideAll()
    {
        _pages.ForEach(page => page.Hide());
    }

    public override void Show()
    {
        _coinView.SetCoinText();
        base.Show();
    }
    public void ShowWinPage()
    {
        HideAll();
        _pages[0].Show();
    }
    public void ShowLosePage()
    {
        HideAll();
        _pages[1].Show();
    }
}
