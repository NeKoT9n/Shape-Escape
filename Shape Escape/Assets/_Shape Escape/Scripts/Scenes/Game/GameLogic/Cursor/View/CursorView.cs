using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using UnityEngine;

public class CursorView : EntityView
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2 _viewOffset;
    [SerializeField] private LayerMask _interactables;
    public LayerMask interactablesMask => _interactables;
    private CursorData _cursorData;

    public void Initialize(CursorData data)
    {
        Cursor.visible = false;
        _cursorData = data;
    }

    public void SetDefaultIcon()
    {
        _spriteRenderer.sprite = _cursorData.Defualt;
    }

    public void SetClickedIcon()
    {
        _spriteRenderer.sprite = _cursorData.Clicked;
    }

    public void SetHoverIcon()
    {
        _spriteRenderer.sprite = _cursorData.Hover;
    }

    public void SetVisable(bool visable)
    {
        _spriteRenderer.gameObject.SetActive(visable);
    }

    public void SetPositionWithOffset(Vector2 mousePosition)
    {
        var postion = mousePosition + _viewOffset;
        //transform.position = postion;
        _rigidbody.MovePosition(postion);
    }

    public override void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
