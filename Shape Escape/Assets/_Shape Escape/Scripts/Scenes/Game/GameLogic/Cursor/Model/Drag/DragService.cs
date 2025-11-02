using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using System;
using UniRx;
using UnityEngine;

public class DragService : IDragService, IInitializable, IDisposable
{
    private readonly IInputService _input;
    private readonly ScriptableObjectContainer _scriptableObjectContainer;
    private DragData _dragData;

    private Rigidbody2D _body;
    private TargetJoint2D _joint;
    private IDisposable _fixedSub;
    private Vector2 _lastMousePos;
    private Vector2 _smoothedMouseVel;


    public DragService(IInputService input, ScriptableObjectContainer scriptableObjectContainer)
    {
        _input = input;
        _scriptableObjectContainer = scriptableObjectContainer;
    }

    public void Initialize()
    {
        _dragData = _scriptableObjectContainer.GetScriptableObject<DragData>();
    }

    public void StartDrag(IDraggable draggable)
    {
        _body = draggable?.Rigidbody;
        if (_body == null) return;

        Vector2 mouseWorld = _input.MouseWorldPosition.Value;
        Vector2 localAnchor = _body.transform.InverseTransformPoint(mouseWorld);

        _joint = _body.gameObject.AddComponent<TargetJoint2D>();
        _joint.autoConfigureTarget = false;
        _joint.anchor = localAnchor;
        _joint.target = mouseWorld;
        _joint.maxForce = _dragData.MaxForce;
        _joint.dampingRatio = _dragData.DampingRatio;
        _joint.frequency = _dragData.Frequency;

        _lastMousePos = mouseWorld;
        _smoothedMouseVel = Vector2.zero;

        _body.gravityScale = _dragData.GravityScaleDuringDrag;
        _body.angularDamping = _dragData.AngularDragDuringDrag;

        _fixedSub = Observable.EveryFixedUpdate().Subscribe(_ => FixedUpdateDrag());
    }

    private void FixedUpdateDrag()
    {
        if (_body == null || _joint == null) return;

        Vector2 mouseWorld = _input.MouseWorldPosition.Value;
        _joint.target = mouseWorld;

        Vector2 rawVel = (mouseWorld - _lastMousePos) / Time.fixedDeltaTime;
        _smoothedMouseVel = Vector2.Lerp(_smoothedMouseVel, rawVel, _dragData.MouseVelocitySmoothing);
        _lastMousePos = mouseWorld;

        // Чтобы при быстром движении мыши joint не демпфировал слишком сильно
        _joint.maxForce = Mathf.Lerp(_joint.maxForce, _dragData.MaxForce, 0.5f);
    }

    public void EndDrag()
    {
        if (_body == null) return;

        // Сохраняем последнюю скорость до уничтожения joint
        Vector2 throwVelocity = _smoothedMouseVel * _dragData.ThrowForceMultiplier;
        throwVelocity = Vector2.ClampMagnitude(throwVelocity, _dragData.MaxThrowSpeed);

        // Сначала удаляем joint, чтобы сила не гасилась
        if (_joint != null)
            UnityEngine.Object.Destroy(_joint);

        // Восстанавливаем физические свойства
        _body.gravityScale = _dragData.RestoreGravityScale;
        _body.angularDamping = _dragData.RestoreAngularDrag;

        // Теперь применяем бросок  
        _body.linearVelocity = throwVelocity;
        

        _fixedSub?.Dispose();
        _fixedSub = null;
        _joint = null;
        _body = null;
        _smoothedMouseVel = Vector2.zero;
    }

    public void Dispose()
    {
        _fixedSub?.Dispose();
        if (_joint != null)
            UnityEngine.Object.Destroy(_joint);
    }
}

