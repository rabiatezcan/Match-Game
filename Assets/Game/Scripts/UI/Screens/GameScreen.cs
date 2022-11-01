using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private LevelView _levelView;
    [SerializeField] private GameplayCoinView _coinView;
    [SerializeField] private TimeView _timeView;
    [SerializeField] private RecipeView _recipeView;

    private LevelController _levelController;
    public void Initialize(LevelController levelController)
    {
        _levelController = levelController;
        UpdateRecipeView();
        _coinView.Initialize();
    }

    public override void Show()
    {
        base.Show();
        _levelController.CurrentLevel.OnRecipeChanged += UpdateRecipeView;
        ScoreSystem.OnScoreAdded += _coinView.CoinAnimation;
        _timeView.Show();
        _levelView.SetLevelText();
        _coinView.SetCoinText();
    }

    public override void Hide()
    {
        if (_levelController != null)
        {
            _levelController.CurrentLevel.OnRecipeChanged -= UpdateRecipeView;
            ScoreSystem.OnScoreAdded += _coinView.CoinAnimation;
            _timeView.Hide();
        }
        base.Hide();
    }

    private void UpdateRecipeView()
    {
        _recipeView.SetRecipe(_levelController.CurrentLevel.CurrentRecipe);
    }
}
