using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private GameEnums.RecipeType _recipeName;
    private Dictionary<GameEnums.VegetableType, int> _recipe = new Dictionary<GameEnums.VegetableType, int>();
    private int _minAmount; 
    private int _maxAmount; 
    public Dictionary<GameEnums.VegetableType, int> RecipeList => _recipe;
    public GameEnums.RecipeType RecipeName => _recipeName;
    public void Initialize(int minAmount, int maxAmount)
    {
        _minAmount = minAmount;
        _maxAmount = maxAmount;
        SetRecipeName();
        GenerateRandomRecipe();
    }
    private void SetRecipeName()
    {
        _recipeName = (GameEnums.RecipeType)Random.Range(0, CONSTANTS.RECIPE_COUNT);
    }
    private void GenerateRandomRecipe()
    {
        for (int i = 0; i < CONSTANTS.RECIPE_VEGETABLE_COUNT; i++)
        {
            bool isAdded = false;
            while (!isAdded)
            {
                GameEnums.VegetableType key = (GameEnums.VegetableType)Random.Range(0, CONSTANTS.VEGETABLE_COUNT);
                int amount = Random.Range(_minAmount, _maxAmount + 1);

                if (!_recipe.ContainsKey(key))
                {
                    _recipe.Add(key, amount);
                    isAdded = true;
                }
            }
        }
    }
}
