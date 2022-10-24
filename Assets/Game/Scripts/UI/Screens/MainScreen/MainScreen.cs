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
        SetActivePage(((int)GameEnums.NavigationBarItems.Home));
        base.Show();
    }

    public void SetActivePage(int item)
    {
        HideAllPages();
        ShowPage(item);
        _bar.SetActivePageButtonColor(item);
    }

    private void ShowPage(int item)
    {
        _pages[((int)item)].Show();
    }
    public void HideAllPages()
    {
        _pages.ForEach(page => page.Hide());
    }
}
