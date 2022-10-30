using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Controller
{
    [SerializeField] List<Screen> _screens;

    private LevelController _levelController;
    #region States
    public override void Initialize(GameManager gameManager)
    {
        ShowMainScreen();
        _levelController = gameManager.LevelController;
       
    } 
    public override void StartGame()
    {
        ShowGameScreen();
    }
    public override void Reload()
    {
        ShowMainScreen();
    }
    public override void GameFail()
    {
        ShowEndScreen();
    }

    public override void GameSuccess()
    {
        ShowEndScreen();
    }
    #endregion

    public void HideAll()
    {
        _screens.ForEach(screen => screen.Hide());
    }

    public void ShowLoadingScreen()
    {
        HideAll();
        _screens[0].Show();
    }   
    public void ShowMainScreen()
    {
        HideAll();
        _screens[1].Show();
    } 
    public void ShowGameScreen()
    {
        HideAll();
        _screens[2].GetComponent<GameScreen>().Initialize(_levelController);
        _screens[2].Show();
    }    
    public void ShowEndScreen()
    {
        HideAll();
        _screens[3].Show();
    }

}
