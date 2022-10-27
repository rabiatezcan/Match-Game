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

    public enum VegetableType
    {
        Beet,
        Brocoli,
        Caper,
        Carrot, 
        Corn, 
        Cucumber, 
        Eggplant, 
        GreenChili, 
        GreenPaprika,
        Leek,
        Lemon, 
        Mushroom, 
        Onion,
        Peas,
        Potato, 
        Pumpkin, 
        Radish,
        RedChili, 
        RedPaprika,
        Spinach,
        Tomato, 
        WhiteOnion,
        YellowChili, 
        YellowPaprika
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
