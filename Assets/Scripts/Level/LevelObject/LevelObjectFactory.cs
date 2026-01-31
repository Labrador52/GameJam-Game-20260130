using UnityEngine;

public static class LevelObjectFactory
{
    public static LevelObject CreateLevelObject(Level level, LevelObjectType type)
    {
        return type switch
        {
            LevelObjectType.Core => new LevelObject(level, 5, 0),
            _ => throw new System.ArgumentException("Invalid LevelObjectType"),
        };
    }
}

public enum LevelObjectType
{
    Core,
    
}