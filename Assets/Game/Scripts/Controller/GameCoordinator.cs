using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : Controller
{
    [SerializeField] private Pan _pan;
    [SerializeField] private TimeHandler _timeHandler;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _timeHandler.Initialize(gameManager.LevelController);
        RecipeCompleteCheckHelper.Initialize(gameManager.LevelController);
    }

    public override void Reload()
    {
        RecipeCompleteCheckHelper.Reload();
    }

    public override void StartGame()
    {
        ScoreSystem.Reload();
        RecipeCompleteCheckHelper.ListenRecipe();
        _timeHandler.StartGame();
        _pan.StartGame();
    }
    public override void GameFail()
    {
        RecipeCompleteCheckHelper.StopListenRecipe();
        _timeHandler.GameOver();
        _pan.GameOver();
    }

    public override void GameSuccess()
    {
        RecipeCompleteCheckHelper.StopListenRecipe();
        RecipeCompleteCheckHelper.Reload();
        _timeHandler.GameOver();
        _pan.GameOver();
    }

    #endregion




}
