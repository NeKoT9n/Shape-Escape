using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.View;

namespace Assets._Shape_Escape.Scripts.Addressable.Providers
{
    [CreateAssetMenu(menuName = "Static/Providers/WorldViewProvider", fileName = "WorldViewProvider")]
    public class WorldViewProvider : ScriptableObject
    {

        [SerializeField] private ShapeAssetReferenceContainer _shapePrefabsData;

        public async UniTask<Dictionary<Type, IEntityView>> Initialize(IAssetProvider assetProvider)
        {

            Dictionary<ShapeType, ShapeView> shapeDictionary = new(_shapePrefabsData.Shapes.Count);

            foreach(var shapeReference in _shapePrefabsData.Shapes)
            {
                ShapeView view = await assetProvider.LoadGameObject<ShapeView>(shapeReference.Shape);
                shapeDictionary.Add(shapeReference.ShapeType, view);
            }

            ShapeViewMap shapeViewMap = new(shapeDictionary);

            return new()
            {
                [typeof(ShapeViewMap)] = shapeViewMap,
            };

        }

    }
}
