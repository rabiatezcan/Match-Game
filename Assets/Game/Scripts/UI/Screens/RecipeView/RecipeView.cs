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

    public void Initialize(Recipe recipe)
    {
        InitializeRecipeItems(recipe);
        SetRecipeName(recipe);
    }

    private void SetRecipeName(Recipe recipe)
    {
        _recipeName.text = recipe.RecipeName.ToString();
    }
    private void InitializeRecipeItems(Recipe recipe)
    {
        for (int i = 0; i < _recipeItems.Count; i++)
        {
            Sprite sprite = _sprites[((int)recipe.RecipeObject.ElementAt(i).Key)];
            int amount = recipe.RecipeObject.ElementAt(i).Value;

            _recipeItems[i].Initialize(sprite, amount);
        }
    }
}
