using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MainScreen : Screen
{
    [SerializeField] private List<Page> _pages;
    [SerializeField] private NavigationBar _bar;

    public override void Show()
    {
        SetActivePage(GameEnums.NavigationBarItems.Home);
        base.Show();
    }
    public void SetActiveHomePage()
    {
        SetActivePage(GameEnums.NavigationBarItems.Home);
    }
    public void SetActiveSettingPage()
    {
        SetActivePage(GameEnums.NavigationBarItems.Setting);
    }
    public void SetActiveShopPage()
    {
        SetActivePage(GameEnums.NavigationBarItems.Shop);
    }
    private void SetActivePage(GameEnums.NavigationBarItems item)
    {
        HideAllPages();
        ShowPage(item);
        _bar.SetActivePageButtonColor(item);
    }

    private void ShowPage(GameEnums.NavigationBarItems item)
    {
        _pages[((int)item)].Show();
    }
    public void HideAllPages()
    {
        _pages.ForEach(page => page.Hide());
    }
}
