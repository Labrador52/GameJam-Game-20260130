using UnityEngine;

public class Level
{
    public Vector2Int Size {get; set;}
    public int RoundCount {get; private set;}
    public int ActionPointCurrent {get; private set;}
    public int ActionPointMax {get; private set;}
    public readonly LevelObject[,] levelObjectMap;
    public LevelObject[] LevelObjects {get; private set;}

    // 当新的 LevelObject 被创建并加入关卡时触发
    public event System.Action<LevelObject> LevelObjectCreated;

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
        LevelObjects = new LevelObject[0];
    }

    /// <summary>
    /// 将一个 LevelObject 加入关卡的格子地图，并触发创建事件
    /// </summary>
    public void AddLevelObject(LevelObject levelObject, Vector2Int position)
    {
        if (position.x < 0 || position.x >= Size.x || position.y < 0 || position.y >= Size.y)
        {
            throw new System.ArgumentOutOfRangeException(nameof(position));
        }
        levelObject.SetPosition(position);
        levelObjectMap[position.x, position.y] = levelObject;

        var list = new System.Collections.Generic.List<LevelObject>(LevelObjects);
        list.Add(levelObject);
        LevelObjects = list.ToArray();

        LevelObjectCreated?.Invoke(levelObject);
    }
}
