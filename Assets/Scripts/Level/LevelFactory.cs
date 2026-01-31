using UnityEngine;

public static class LevelFactory
{
    public static Level CreateLevel(Vector2Int size)
    {
        Level level = new Level(size);

        // 创建一个 Core LevelObject 并放在 (4,4)（基于 0 索引）
        var core = LevelObjectFactory.CreateLevelObject(level, LevelObjectType.Core);
        Vector2Int corePos = new Vector2Int(4, 4);
        level.AddLevelObject(core, corePos);

        return level;
    }
}