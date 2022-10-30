using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : Controller
{
    [SerializeField] private Pan _pan;
    #region Core
    public override void Initialize(GameManager gameManager)
    {
        RecipeCompleteCheckHelper.Initialize(gameManager.LevelController);
    }

    public override void Reload()
    {
    }

    public override void StartGame()
    {
    }
    public override void GameFail()
    {
    }

    public override void GameSuccess()
    {
    }

    #endregion




}
