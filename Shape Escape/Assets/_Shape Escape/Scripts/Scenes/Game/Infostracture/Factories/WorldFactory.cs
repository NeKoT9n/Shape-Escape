using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.View;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape;
using UnityEngine;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.Factories
{
    public class WorldFactory
    {

        private readonly DiContainer _diContainer;
        private readonly WorldViewContainer _worldViewContainer;

        public WorldFactory(DiContainer diContainer, WorldViewContainer worldViewContainer)
        {
            _diContainer = diContainer;
            _worldViewContainer = worldViewContainer;
        }

        public TResult SpawnWorldEntity<TResult>(Vector3 at) where TResult : class, IEntityView
        {
            TResult prefab = _worldViewContainer.GetWorldEntity<TResult>();

            return _diContainer.InstantiatePrefab(prefab.GameObject, at, Quaternion.identity, null)
                               .GetComponent<TResult>();
        }

        public TResult SpawnWorldEntity<TResult>(IEntityView worldEntity, Vector3 at) where TResult : class, IEntityView
        {
            return _diContainer.InstantiatePrefab(worldEntity.GameObject, at, Quaternion.identity, null)
                               .GetComponent<TResult>();
        }

        public ShapeView SpawnShape(ShapeType type, Vector3 at)
        {
            var shapeMap = _worldViewContainer.GetWorldEntity<ShapeViewMap>();
            var prefab = shapeMap.Get(type);

            if (prefab == null)
            {
                Debug.LogError($"Shape prefab for {type} is missing in WorldViewProvider!");
                return null;
            }

            return _diContainer.InstantiatePrefab(prefab.GameObject, at, Quaternion.identity, null)
                               .GetComponent<ShapeView>();
        }

    }
}
