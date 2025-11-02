using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Interactables;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag
{
    public interface IDraggable : IInteractable
    {
        public Rigidbody2D Rigidbody { get; }
        public void OnDragStart();
        public void OnDragEnd();
    }
}
