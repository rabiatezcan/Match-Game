using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour, ISelectableObject
{
    [SerializeField] private MovementSettings _movementSetting;

    private Vector3 offset;
    #region ISelectable
    public void Select(Vector3 inputPos)
    {
    }

    public void Drag(Vector3 inputPos)
    {
        inputPos.x = Mathf.Clamp(inputPos.x, _movementSetting.MinX, _movementSetting.MaxX);
        inputPos.z -= .63f;
        inputPos.z = Mathf.Clamp(inputPos.z, _movementSetting.MinY, _movementSetting.MaxY);
        inputPos.y = 0f;
        transform.position = inputPos;
    }

    public void Drop()
    {
    }

   
    #endregion

}
