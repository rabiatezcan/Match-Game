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

    public enum RecipeType
    {
        Soup, 
        Spaghetti, 
        Salad
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
        Potato, 
        Pumpkin, 
        RedChili, 
        RedPaprika,
        Spinach,
        Squash,
        Tomato, 
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
