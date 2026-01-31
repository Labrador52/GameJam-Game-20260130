using UnityEngine;

public class Level
{
    public Vector2Int Size {get; set;}
    public int RoundCount {get; private set;}
    public int ActionPointCurrent {get; private set;}
    public int ActionPointMax {get; private set;}
    public readonly LevelObject[,] levelObjectMap;
    public LevelObject[] LevelObjects {get; private set;}

    public void ExecuteRound()
    {
        foreach (var levelObject in LevelObjects)
        {
            levelObject.StartRoundAction(this);
        }
        RoundCount++;
        ActionPointCurrent = ActionPointMax;
    }

    public void TryExecuteLevelAction(LevelAction action, LevelObject levelObject)
    {
        if (ActionPointCurrent >= action.ActionPointCost)
        {
            action.Execute(this, levelObject);
            ActionPointCurrent -= action.ActionPointCost;
        }
    }

    public bool TryGetLevelObjectAtPosition(Vector2Int position, out LevelObject levelObject)
    {
        levelObject = null;
        if (position.x < 0 || position.x >= Size.x || position.y < 0 || position.y >= Size.y)
        {
            return false;
        }
        levelObject = levelObjectMap[position.x, position.y];
        if (levelObject != null)
        {
            return true;
        }
        return false;
    }

    public Level(Vector2Int size)
    {
        Size = size;
        levelObjectMap = new LevelObject[size.x, size.y];
        RoundCount = 1;
        ActionPointMax = 5;
        ActionPointCurrent = ActionPointMax;
    }
}
