using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Model
{
    public class ShapeFactory : IInitializable
    {
        private readonly ScriptableObjectContainer _scriptableObjectContainer;
        private readonly ShapeService _shapeService;
        private Dictionary<ShapeType, ShapeData> _shapeDatas;

        private List<Shape> _createdShapes;
        public IReadOnlyList<Shape> Shapes => _createdShapes;

        public ShapeFactory(ScriptableObjectContainer scriptableObjectContainer, ShapeService shapeService)
        {
            _scriptableObjectContainer = scriptableObjectContainer;
            _shapeService = shapeService;
        }

        public void Initialize()
        {
            var datas = _scriptableObjectContainer.GetScriptableObject<ShapeDataContainer>().ShapeDatas;
            _shapeDatas = new (datas.Count);

            foreach (var data in datas)
            {
                _shapeDatas.Add(data.Type, data);
            }
            var shapeSpawnPoints = Object.FindObjectsByType<ShapeSpawnPoint>(FindObjectsSortMode.None);

            _createdShapes = new(shapeSpawnPoints.Length);

            foreach(var spawnPoint in shapeSpawnPoints)
            {
                var shape = CreateShape(spawnPoint);
                _shapeService.AddShape(shape);
            }
        }

        public Shape CreateShape(ShapeSpawnPoint spawnPoint)
        {
            var data = _shapeDatas[spawnPoint.ShapeType];
            var shape = new Shape(data);
            shape.SetStartPosition(spawnPoint.Position);
            shape.SetTeam(spawnPoint.Team);

            return shape;
        }
    }
}
