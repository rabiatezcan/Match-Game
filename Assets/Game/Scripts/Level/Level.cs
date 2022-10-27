using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    [SerializeField] private ObjectClampSettings _vegetableSpawnSetting;
    private List<Vegetable> _levelObjects = new List<Vegetable>();
    private Recipe[] _recipes = new Recipe[2];
    private Recipe _currentRecipe;
    public Recipe CurrentRecipe => _currentRecipe; 
    public void Build()
    {
        InitializeRecipes();

        GenerateLevelObjects();
    }
    public void Remove()
    {
        //_levelObjects.ForEach(obj => obj.Dismiss());
        _levelObjects.Clear();
    }

    private void InitializeRecipes()
    {
        for (int i = 0; i < _recipes.Length; i++)
        {
            _recipes[i] = new Recipe();
        }

        _currentRecipe = _recipes[0];
    }

    private void GenerateLevelObjects()
    {
        for (int i = 0; i < CONSTANTS.VEGETABLE_COUNT; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                Vegetable vegetable = PoolHandler.Instance.GetItemFromPool("Vegetable") as Vegetable;
                vegetable.Initialize((GameEnums.VegetableType)i);
                vegetable.SetPosition(GetRandomPosition());
                vegetable.SetActive();
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        float xAxis = Random.Range(_vegetableSpawnSetting.MinX, _vegetableSpawnSetting.MaxX);
        float zAxis = Random.Range(_vegetableSpawnSetting.MinZ, _vegetableSpawnSetting.MaxZ);
        return new Vector3(xAxis, 0f, zAxis);
    }
}
