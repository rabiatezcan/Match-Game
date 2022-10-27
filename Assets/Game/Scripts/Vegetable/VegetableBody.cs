using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableBody : MonoBehaviour
{
    [SerializeField] private List<Transform> _bodies;

    public void Initialize(GameEnums.VegetableType type)
    {

        SetBody(type);
    }

    private void SetBody(GameEnums.VegetableType type)
    {

        HideAll();
        _bodies[((int)type)].gameObject.SetActive(true);
    }

    private void HideAll()
    {
        _bodies.ForEach(body => body.gameObject.SetActive(false));

    }
}
