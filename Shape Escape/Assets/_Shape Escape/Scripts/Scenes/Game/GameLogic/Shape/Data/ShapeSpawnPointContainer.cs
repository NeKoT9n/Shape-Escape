using System.Collections.Generic;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data
{
    [CreateAssetMenu(menuName = "Static/Datas/Containers/ShapeSpawnPoints", fileName = "ShapeSpawnPoints")]
    public class ShapeSpawnPointContainer : ScriptableObject
    {
        [SerializeField] private List<ShapeSpawnPoint> _spawnPoints;

        public IReadOnlyList<ShapeSpawnPoint> SpawnPoints => _spawnPoints;
    }
}
