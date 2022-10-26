using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(menuName = "Game/Movement Settings", order = 2)]
    public class MovementSettings : ScriptableObject
    {
        [Header("Movement Parameters")]
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX; 
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;

        public float MinX => _minX;
        public float MaxX => _maxX;
        public float MinY => _minY;
        public float MaxY => _maxY;
    }
}