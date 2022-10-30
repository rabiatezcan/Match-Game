using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecipeView : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<RecipeItem> _recipeItems;
    [SerializeField] private Text _recipeName;

    private Recipe _currentRecipe;

    public void SetRecipe(Recipe recipe)
    {
        _currentRecipe = recipe;
        InitializeRecipeItems();
        SetRecipeName();
    }
    private void SetRecipeName()
    {
        _recipeName.text = _currentRecipe.RecipeName.ToString();
    }
    private void InitializeRecipeItems()
    {
        for (int i = 0; i < _recipeItems.Count; i++)
        {
            Sprite sprite = _sprites[((int)_currentRecipe.RecipeList.ElementAt(i).Key)];
            int amount = _currentRecipe.RecipeList.ElementAt(i).Value;

            _recipeItems[i].Initialize(sprite, amount);
        }
    }
}
