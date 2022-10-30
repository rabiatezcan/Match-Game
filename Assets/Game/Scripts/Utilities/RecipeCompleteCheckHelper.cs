using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RecipeCompleteCheckHelper 
{
    private static LevelController _levelController;
    private static Recipe _currentRecipe;
    private static Dictionary<GameEnums.VegetableType, int> _recipeVegetables = new Dictionary<GameEnums.VegetableType, int>();


    public static void Initialize(LevelController levelController)
    {
        _levelController = levelController;
        _levelController.CurrentLevel.OnRecipeChanged += UpdateRecipe;
        SetRecipe();
        SetRecipeVegetables();
    }

    public static void CheckRecipe(Vegetable vegetable)
    {
        AddVegetable(vegetable);

        if (IsRecipeCompleted())
            _levelController.CurrentLevel.ChangeRecipe();
    }

    private static void UpdateRecipe()
    {
        Clear();
        SetRecipe();
        SetRecipeVegetables();
    }

    private static void Clear()
    {
        _recipeVegetables.Clear();
    }

    private static void SetRecipe()
    {
        _currentRecipe = _levelController.CurrentLevel.CurrentRecipe;
    }

    private static bool IsRecipeCompleted()
    {
        return _recipeVegetables.All(recipeElement => recipeElement.Value == _currentRecipe.RecipeList[recipeElement.Key]);
    }

    private static void AddVegetable(Vegetable vegetable)
    {
        _recipeVegetables[vegetable.BodyType]++;
    }

    private static void SetRecipeVegetables()
    {
        for (int i = 0; i < _currentRecipe.RecipeList.Count; i++)
        {
            _recipeVegetables.Add(_currentRecipe.RecipeList.ElementAt(i).Key, 0);
        }
    }

   

}
