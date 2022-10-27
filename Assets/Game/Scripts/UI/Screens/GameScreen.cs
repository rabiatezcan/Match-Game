using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private LevelView _levelView;
    [SerializeField] private CoinView _coinView;
    [SerializeField] private TimeView _timeView;
    [SerializeField] private RecipeView _recipeView;
    
    public void Initialize(LevelController levelController)
    {
        _recipeView.Initialize(levelController.CurrentLevel.CurrentRecipe);
    }

    public override void Show()
    {
        base.Show();
    }

}
