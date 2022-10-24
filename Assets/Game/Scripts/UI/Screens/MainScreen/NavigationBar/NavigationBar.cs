using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBar : MonoBehaviour
{
    [SerializeField] private List<Image> _buttonImages;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectColor;

    public void SetActivePageButtonColor(int item)
    {
        _buttonImages.ForEach(btnImage => btnImage.color = _defaultColor);
        _buttonImages[item].color = _selectColor;
    }
}
