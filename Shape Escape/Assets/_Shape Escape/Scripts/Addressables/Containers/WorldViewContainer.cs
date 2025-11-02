using Assets._Shape_Escape.Scripts.Addressable.Providers;
using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Assets._Shape_Escape.Scripts.Addressable.Containers
{
    public class WorldViewContainer : IAsyncInitializable
    {
        private readonly IAssetProvider _assetProvider;
        private WorldViewProvider _worldViewProvider;

        private Dictionary<Type, IEntityView> _worldEntityMap;
        public WorldViewContainer(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }


        public TResult GetWorldEntity<TResult>() where TResult : class =>
            _worldEntityMap.TryGetValue(typeof(TResult), out var worldEntity) ? worldEntity as TResult : null;

        public async UniTask Initialize()
        {
            _worldViewProvider = await _assetProvider.Load<WorldViewProvider>(nameof(WorldViewProvider));

            _worldEntityMap = await _worldViewProvider.Initialize(_assetProvider);
        }
    }
}
