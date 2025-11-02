using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using System;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Lazers.View
{
    public class LazerView : MonoBehaviour
    {

        public event Action<EntityView, Team> Colided;
        [SerializeField] private Team _team;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EntityView entity))
            {
                entity.OnLizerColided(_team);
            }
        }
    }
}