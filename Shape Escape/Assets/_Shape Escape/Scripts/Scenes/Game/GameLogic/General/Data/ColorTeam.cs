using System.Collections;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General
{
    [CreateAssetMenu(menuName =("Static/Datas/ColorTeam"), fileName =("Team_"))]
    public class ColorTeam : ScriptableObject
    {
        [SerializeField] private Color _color;
        [SerializeField] private Team _team;

        public Color Color => _color;
        public Team Team => _team;
    }
}