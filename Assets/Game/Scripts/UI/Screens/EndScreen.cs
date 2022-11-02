using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : Screen
{
    [SerializeField] private List<Page> _pages;
    [SerializeField] private CoinView _coinView;
    [SerializeField] private Button _extraTimeButton;

    private LevelController _levelController;
  

    public override void Show()
    {
        _coinView.SetCoinText();
        CheckButtonInteractable();
        base.Show();
    }

    public void Initialize(LevelController levelController)
    {
        _levelController = levelController;
    }

    private void HideAll()
    {
        _pages.ForEach(page => page.Hide());
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

    public void CheckButtonInteractable()
    {
        if (PlayerHelper.Instance.Player.Coin >= CONSTANTS.EXTRA_TIME_COIN)
            _extraTimeButton.interactable = true;
        else
            _extraTimeButton.interactable = false;
    }

    public void GetExtraTime()
    {
        PlayerHelper.Instance.UpdateCoin(-CONSTANTS.EXTRA_TIME_COIN);
        _levelController.CurrentLevel.LevelTimeForSecond = CONSTANTS.EXTRA_TIME;
        GameManager.Instance.StartGame();
    }
    public void UpdateLevel()
    {
        GameManager.Instance.Reload();
        GameManager.Instance.StartGame();
    }
}
