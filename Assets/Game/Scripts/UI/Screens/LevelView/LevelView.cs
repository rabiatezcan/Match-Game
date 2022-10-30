using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Text _levelTxt; 

    public void SetLevelText()
    {
        _levelTxt.text = "Level " + PlayerHelper.Instance.Player.Level;
    }
}
