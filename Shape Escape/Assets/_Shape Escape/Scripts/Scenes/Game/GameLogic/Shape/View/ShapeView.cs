using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShapeView : EntityView, IDraggable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public Rigidbody2D Rigidbody => _rigidbody;

        private Rigidbody2D _rigidbody;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void OnDragEnd()
        {
            
        }

        public void OnDragStart()
        {
            
        }

        public void OnHoverEnter()
        {
            Debug.Log("Hover Enter");
        }

        public void OnHoverExit()
        {
            Debug.Log("Hover Exit");
        }

        public void OnInteract()
        {
            Debug.Log("Clicked");
        }

        public override void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}