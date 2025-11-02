using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.Factories;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Model
{
    public class ShapeSpawner
    {
        private readonly WorldFactory _worldFactory;

        public ShapeSpawner(WorldFactory worldFactory)
        {
            _worldFactory = worldFactory;
        }

        public ShapeView Create(Shape shape)
        {
            return _worldFactory.SpawnShape(shape.ShapeData.Type, shape.StartPosition);
        }

        public ShapeView Create(Shape shape, Transform parent)
        {
            var go = Create(shape);
            go.transform.parent = parent;

            return go;
        }
    }
}
