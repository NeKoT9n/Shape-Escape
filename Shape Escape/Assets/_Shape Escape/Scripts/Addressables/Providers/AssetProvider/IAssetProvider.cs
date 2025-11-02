using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._Shape_Escape.Scripts.Addressable.Providers
{
    public interface IAssetProvider
    {
        public UniTask<TResult> Load<TResult>(AssetReference assetReference) where TResult : class;
        public UniTask<TResult> LoadGameObject<TResult>(AssetReference assetReference) where TResult : Object;
        public UniTask<TResult> Load<TResult>(string assetReferenceName) where TResult : class;

    }
}