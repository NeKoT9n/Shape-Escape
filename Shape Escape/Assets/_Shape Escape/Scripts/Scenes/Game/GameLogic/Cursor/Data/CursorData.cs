using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Data
{
    [CreateAssetMenu(menuName =("Static/Datas/Cursor"), fileName =("Cursor Data"))]
    public class CursorData : ScriptableObject
    {
        [SerializeField] private Team _startTeam;
        [SerializeField] private Sprite _defualt;
        [SerializeField] private Sprite _hover;
        [SerializeField] private Sprite _clicked;

        public Team StartTeam => _startTeam;
        public Sprite Defualt => _defualt;
        public Sprite Hover => _hover;
        public Sprite Clicked => _clicked;
    }
}