using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PlayerData
{
    public int Level { get; set; }
    public int Coin { get; set; }
    public bool IsSoundOn { get; set; }
    public bool IsVibrationOn { get; set; }


    public void Build()
    {
        Level = 1;
        Coin = 0;
        IsSoundOn = true;
        IsVibrationOn = true;
    }





}
