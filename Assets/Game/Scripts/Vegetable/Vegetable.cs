using DG.Tweening;
using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : PoolObject, ISelectableObject
{
    [SerializeField] private ObjectClampSettings _clampSetting;
    [SerializeField] private VegetableBody _body;

    private GameEnums.ClickType _currentClickType;
    private GameEnums.VegetableType _bodyType;
    private bool _onPanArea;
    private bool _isRecipeElement;
    public bool OnPanArea
    {
        get => _onPanArea;
        set => _onPanArea = value;
    }
    public bool IsRecipeElement
    {
        get => _isRecipeElement;
        set => _isRecipeElement = value;
    }
    public GameEnums.VegetableType BodyType 
    {
        get => _bodyType; 
        set => _bodyType = value; }

    #region Core
    public void Initialize(GameEnums.VegetableType type, bool isRecipeElement)
    {
        _bodyType = type;
        _isRecipeElement = isRecipeElement;
        _body.Initialize(type);
    }
    #endregion

    #region ISelectable
    public void Select(GameEnums.ClickType clickType)
    {
        _currentClickType = clickType;

        if (_currentClickType == GameEnums.ClickType.Double)
            JumpAnimation(PanRandomPositionHelper.GetRandomPosition(), Ease.OutCubic);
    }

    public void Drag(Vector3 inputPos)
    {
        if (_currentClickType == GameEnums.ClickType.Double)
            return;

        inputPos.x = Mathf.Clamp(inputPos.x, _clampSetting.MinX, _clampSetting.MaxX);
        inputPos.z -= .63f;
        inputPos.z = Mathf.Clamp(inputPos.z, _clampSetting.MinZ, _clampSetting.MaxZ);
        inputPos.y = 0f;
        transform.position = inputPos;
    }

    public void Drop()
    {
        if (OnPanArea)
            JumpAnimation(Vector3.zero, Ease.InOutBack);
    }
    #endregion

    private void JumpAnimation(Vector3 jumpPos, Ease ease)
    {
        transform.DOJump(jumpPos, 15f, 1, .5f).SetEase(ease)
                 .OnComplete(() => Check());
    }

    private void Check()
    {
        if (OnPanArea)
        {
            if (!IsRecipeElement)
                JumpAnimation(Vector3.zero, Ease.InOutBack);
            else
                RecipeCompleteCheckHelper.CheckRecipe(this);
        }
    }
}
