using System.Collections.Generic;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data
{
    [CreateAssetMenu(menuName = "Static/Datas/Containers/ShapeDataContainer", fileName = "ShapeDataContainer")]
    public class ShapeDataContainer : ScriptableObject
    {
        [SerializeField] private List<ShapeData> _shapeDatas;

        public IReadOnlyList<ShapeData> ShapeDatas => _shapeDatas;
    }
}
