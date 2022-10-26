using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnums
{
    public enum ClickType
    {
        Single, 
        Double
    }
    public enum TriggerBehaviour
    {
        OnTriggerEnter,
        OnTriggerExit, 
        Both
    }

    public enum NavigationBarItems
    {
        Shop, 
        Home,
        Setting
    }
}
