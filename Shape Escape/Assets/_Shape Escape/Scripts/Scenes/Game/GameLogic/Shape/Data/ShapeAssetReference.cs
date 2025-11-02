using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data
{
    [CreateAssetMenu(menuName = "Static/Datas/ShapeReference", fileName = "ShapeAssetReference")]
    public class ShapeAssetReference : ScriptableObject
    {

        [SerializeField] private ShapeType _shapeType;
        [SerializeField] private AssetReferenceGameObject _shape;

        public ShapeType ShapeType => _shapeType;
        public AssetReferenceGameObject Shape => _shape;
    }
}
