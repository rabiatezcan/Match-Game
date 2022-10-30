using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : Page
{
    [SerializeField] private LevelView _levelView;
    [SerializeField] private ChestView _chestView;

    public override void Show()
    {
        base.Show();
        _chestView.Show();
        _levelView.SetLevelText();
    }

}
