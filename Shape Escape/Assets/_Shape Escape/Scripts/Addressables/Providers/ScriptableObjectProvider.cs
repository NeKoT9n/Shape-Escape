using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._Shape_Escape.Scripts.Addressable.Providers
{
    [CreateAssetMenu(menuName =("Static/Providers/ScriptableObjectProvider"),fileName =("ScriptableObjectProvider"))]
    public class ScriptableObjectProvider : ScriptableObject
    {
        [SerializeField] private AssetReferenceT<CursorData> _cursorData;
        [SerializeField] private AssetReferenceT<TeamsData> _teamsData;
        [SerializeField] private AssetReferenceT<DragData> _dragData;
        [SerializeField] private AssetReferenceT<ShapeDataContainer> _shapeDatas;
        public async UniTask<Dictionary<Type, ScriptableObject>> Initialize(IAssetProvider assetProvider)
        {
            return new()
            {
                [typeof(CursorData)] = await assetProvider.Load<CursorData>(_cursorData),
                [typeof(TeamsData)] = await assetProvider.Load<TeamsData>(_teamsData),
                [typeof(DragData)] = await assetProvider.Load<DragData>(_dragData),
                [typeof(ShapeDataContainer)] = await assetProvider.Load<ShapeDataContainer>(_shapeDatas),
            };
        }
    }
}