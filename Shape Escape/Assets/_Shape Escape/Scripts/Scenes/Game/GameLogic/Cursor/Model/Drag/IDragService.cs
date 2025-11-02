namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag
{
    public interface IDragService
    {
        public void StartDrag(IDraggable draggable);
        public void EndDrag();
    }
}
