using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data
{
    public class ShapeSpawnPoint : MonoBehaviour
    {
        [SerializeField] private ShapeType _shapeType;
        [SerializeField] private Team _team;

        public Vector3 Position => transform.position;
        public ShapeType ShapeType => _shapeType;
        public Team Team => _team;
    }
}
