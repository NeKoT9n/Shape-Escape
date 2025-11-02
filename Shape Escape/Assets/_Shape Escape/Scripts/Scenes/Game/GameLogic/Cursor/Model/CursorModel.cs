using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;

public class CursorModel : Entity
{
    private readonly CursorData _cursorData;

    public CursorData CursorData => _cursorData;

    public CursorModel(CursorData cursorData)
    {
        _cursorData = cursorData;
        SetTeam(cursorData.StartTeam);

    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }
}
