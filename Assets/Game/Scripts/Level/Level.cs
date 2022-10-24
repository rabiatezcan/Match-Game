using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<PoolObject> _levelObjects = new List<PoolObject>();

    public void Initialize()
    {
    }
    public void Build()
    {

    }
    public void Remove()
    {
        _levelObjects.ForEach(obj => obj.Dismiss());
        _levelObjects.Clear();
    }
}
