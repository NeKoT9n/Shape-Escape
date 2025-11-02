using System;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View
{
    public abstract class EntityView : MonoBehaviour, IEntityView
    {
        public GameObject GameObject => gameObject;

        public event Action<Team> Colided;

        public void OnLizerColided(Team team)
        {
            Colided?.Invoke(team);
        }

        public abstract void SetColor(Color color);

    }
}