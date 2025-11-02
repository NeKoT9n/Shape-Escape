using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape
{
    [CreateAssetMenu(menuName = "Static/Datas/ShapeData", fileName = "ShapeData")]
    public class ShapeData : ScriptableObject
    {
        [SerializeField] private ShapeType _shapeType;
        [SerializeField] private float _mass = 1f;
        [SerializeField] private float _bounciness = 0.2f;
        [SerializeField] private float _drag = 0.5f;

        public ShapeType Type => _shapeType;
        public float Mass => _mass;
        public float Bounciness => _bounciness;
        public float Drag => _drag;
    }
}
