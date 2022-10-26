using DG.Tweening;
using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour, ISelectableObject
{
    [SerializeField] private MovementSettings _movementSetting;

    private GameEnums.ClickType _currentClickType;
    private bool _onPanArea;

    public bool OnPanArea 
    {
        get => _onPanArea; 
        set => _onPanArea = value;
    }

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

        inputPos.x = Mathf.Clamp(inputPos.x, _movementSetting.MinX, _movementSetting.MaxX);
        inputPos.z -= .63f;
        inputPos.z = Mathf.Clamp(inputPos.z, _movementSetting.MinY, _movementSetting.MaxY);
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
