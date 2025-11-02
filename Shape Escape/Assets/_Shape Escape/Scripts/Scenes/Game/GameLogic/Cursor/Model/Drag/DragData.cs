using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag
{
    [CreateAssetMenu(menuName =("Static/Datas/DragData"), fileName =("DragData"))]
    public class DragData : ScriptableObject
    {
        [SerializeField] private float _maxForce = 1000f;
        [SerializeField] private float _dampingRatio = 0.8f;
        [SerializeField] private float _frequency = 8f;

        [SerializeField] private float _gravityScaleDuringDrag = 0.2f;
        [SerializeField] private float _angularDragDuringDrag = 10f;

        [SerializeField] private float _throwForceMultiplier = 0.02f;
        [SerializeField] private float _maxThrowSpeed = 25f;

        [SerializeField, Range(0f, 1f)] private float _mouseVelocitySmoothing = 0.5f;

        [SerializeField] private float _restoreGravityScale = 1f;
        [SerializeField] private float _restoreAngularDrag = 0.05f;

        public float MaxForce => _maxForce;
        public float DampingRatio => _dampingRatio;
        public float Frequency => _frequency;

        public float GravityScaleDuringDrag => _gravityScaleDuringDrag;
        public float AngularDragDuringDrag => _angularDragDuringDrag;

        public float ThrowForceMultiplier => _throwForceMultiplier;
        public float MaxThrowSpeed => _maxThrowSpeed;

        public float MouseVelocitySmoothing => _mouseVelocitySmoothing;

        public float RestoreGravityScale => _restoreGravityScale;
        public float RestoreAngularDrag => _restoreAngularDrag;
    }
}
