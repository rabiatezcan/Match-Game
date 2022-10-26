using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectableObject
{
    public void Select(GameEnums.ClickType clickType);

    public void Drag(Vector3 inputPos);

    public void Drop();
}
