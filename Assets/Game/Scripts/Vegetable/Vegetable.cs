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

    public bool OnPanArea 
    {
        get => _onPanArea; 
        set => _onPanArea = value;
    }

    #region Core
    public void Initialize(GameEnums.VegetableType type)
    {
        _bodyType = type;
        _body.Initialize(type);
    }
    #endregion

    #region ISelectable
    public void Select(GameEnums.ClickType clickType)
    {
        _currentClickType = clickType;

        if (_currentClickType == GameEnums.ClickType.Double)
            JumpAnimation(PanRandomPositionHelper.GetRandomPosition());
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
            JumpAnimation(Vector3.zero);
    }
    #endregion

    private void JumpAnimation(Vector3 jumpPos)
    {
        transform.DOJump(jumpPos, 15f, 1, .5f).SetEase(Ease.OutCubic);
    }
}
