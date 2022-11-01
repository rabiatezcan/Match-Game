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
        _recipeView.SetRecipe(_levelController.CurrentLevel.CurrentRecipe);
        _coinView.Initialize();
    }

    public override void Show()
    {
        base.Show();
        _coinView.OnCoinAnimationCompleted += UpdateRecipe;
        RecipeCompleteCheckHelper.OnRecipeCompleted += _coinView.CoinAnimation;
        ScoreSystem.OnScoreAdded += _coinView.SetCoinText;
        _timeView.Show();
        _levelView.SetLevelText();
        _coinView.SetCoinText();
    }

    public override void Hide()
    {
        if (_levelController != null)
        {
            _coinView.OnCoinAnimationCompleted -= UpdateRecipe;
            RecipeCompleteCheckHelper.OnRecipeCompleted -= _coinView.CoinAnimation;
            ScoreSystem.OnScoreAdded -= _coinView.SetCoinText;
            _timeView.Hide();
        }
        base.Hide();
    }

    private void UpdateRecipe()
    {
        _levelController.CurrentLevel.ChangeRecipe();
        
        _recipeView.SetRecipe(_levelController.CurrentLevel.CurrentRecipe);
    }
}
