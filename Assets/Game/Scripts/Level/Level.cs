using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    public Action OnRecipeChanged;

    [SerializeField] private ObjectClampSettings _vegetableSpawnSetting;
    [SerializeField] private float _levelTimeForSecond;
    [SerializeField] private int _minCountPerVegetableType;
    [SerializeField] private int _maxCountPerVegetableType;

    private List<Vegetable> _levelObjects = new List<Vegetable>();
    private Recipe[] _recipes = new Recipe[2];
    private Recipe _currentRecipe;
    private int _currentRecipeIndex = 0;
    public Recipe CurrentRecipe
    {
        get => _currentRecipe;
    }
    public float LevelTimeForSecond
    {
        get => _levelTimeForSecond;
        set => _levelTimeForSecond = value;
    } 

    public void Build()
    {
        InitializeRecipes();

        GenerateLevelObjects();
    }
    public void Remove()
    {
        _levelObjects.ForEach(obj => obj.Dismiss());
        _levelObjects.Clear();
    }

    public void ChangeRecipe()
    {
        _currentRecipeIndex++;

        if (_currentRecipeIndex < _recipes.Length)
        {
            _currentRecipe = _recipes[_currentRecipeIndex];
            UpdateLevelObjects();
            OnRecipeChanged?.Invoke();
        }
        else
            GameManager.Instance.GameSuccess();
    }
    private void InitializeRecipes()
    {
        for (int i = 0; i < _recipes.Length; i++)
        {
            _recipes[i] = new Recipe();
            _recipes[i].Initialize(_minCountPerVegetableType, _maxCountPerVegetableType);
        }

        _currentRecipe = _recipes[_currentRecipeIndex];
    }

    private void GenerateLevelObjects()
    {
        for (int i = 0; i < CONSTANTS.VEGETABLE_COUNT; i++)
        {
            for (int j = 0; j < (_maxCountPerVegetableType * 2); j++)
            {
                bool isRecipeElement = _currentRecipe.RecipeList.ContainsKey((GameEnums.VegetableType)i);

                Vegetable vegetable = PoolHandler.Instance.GetItemFromPool("Vegetable") as Vegetable;
                vegetable.Initialize((GameEnums.VegetableType)i, isRecipeElement);
                vegetable.SetPosition(GetRandomPosition());
                vegetable.SetActive();

                _levelObjects.Add(vegetable);
            }
        }
    }
    private void UpdateLevelObjects()
    {
        _levelObjects.ForEach(obj =>
        {
            obj.SetPosition(GetRandomPosition());
            obj.IsRecipeElement = _currentRecipe.RecipeList.ContainsKey(obj.BodyType);
            obj.CanMove = true;
        });
    }
    private Vector3 GetRandomPosition()
    {
        float xAxis = Random.Range(_vegetableSpawnSetting.MinX, _vegetableSpawnSetting.MaxX);
        float zAxis = Random.Range(_vegetableSpawnSetting.MinZ, _vegetableSpawnSetting.MaxZ);
        return new Vector3(xAxis, 0f, zAxis);
    }


}
