using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("Static/Datas/Teams"), fileName =("Teams"))]
public class TeamsData : ScriptableObject
{
    [SerializeField] private List<ColorTeam> _teams;
    public IReadOnlyList<ColorTeam> Teams => _teams;   
}
