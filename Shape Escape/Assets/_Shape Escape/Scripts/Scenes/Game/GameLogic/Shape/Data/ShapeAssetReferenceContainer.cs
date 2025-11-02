using System.Collections.Generic;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data
{
    [CreateAssetMenu(menuName = "Static/Datas/Containers/ShapesPrefabs", fileName = "Prefabs")]
    public class ShapeAssetReferenceContainer : ScriptableObject
    {
        [SerializeField] private List<ShapeAssetReference> _shapes;

        public IReadOnlyList<ShapeAssetReference> Shapes => _shapes;
    }
}
