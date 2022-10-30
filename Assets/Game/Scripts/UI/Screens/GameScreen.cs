using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private LevelView _levelView;
    [SerializeField] private CoinView _coinView;
    [SerializeField] private TimeView _timeView;
    [SerializeField] private RecipeView _recipeView;

    private LevelController _levelController;
    public void Initialize(LevelController levelController)
    {
        _levelController = levelController;
        UpdateRecipeView();
    }

    public override void Show()
    {
        base.Show();
        _levelController.CurrentLevel.OnRecipeChanged += UpdateRecipeView;
    }

    public override void Hide()
    {
        if (_levelController != null)
            _levelController.CurrentLevel.OnRecipeChanged -= UpdateRecipeView;
        base.Hide();
    }

    private void UpdateRecipeView()
    {
        _recipeView.SetRecipe(_levelController.CurrentLevel.CurrentRecipe);
    }
}
