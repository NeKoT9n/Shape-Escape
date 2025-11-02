using Assets._Shape_Escape.Scripts.Addressable.Providers;
using Assets._Shape_Escape.Scripts.General;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Addressable.Containers
{
    public class ScriptableObjectContainer : IAsyncInitializable
    {
        private readonly IAssetProvider _assetProvider;
        private ScriptableObjectProvider _scriptableObjectProvider;

        private Dictionary<Type, ScriptableObject> _scriptableObjectsMap = new();

        public ScriptableObjectContainer(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
            _scriptableObjectProvider = await _assetProvider.Load<ScriptableObjectProvider>(nameof(ScriptableObjectProvider));

            _scriptableObjectsMap = await _scriptableObjectProvider.Initialize(_assetProvider);
        }

        public TResult GetScriptableObject<TResult>() where TResult : ScriptableObject =>
            _scriptableObjectsMap.TryGetValue(typeof(TResult), out var result) ? result as TResult : null;

    }
}