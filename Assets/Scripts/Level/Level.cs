using UnityEngine;

public class Level
{
    public Vector2Int Size {get; set;}
    public int RoundCount {get; private set;}
    public int ActionPointCurrent {get; private set;}
    public int ActionPointMax {get; private set;}
    public readonly LevelObject[,] levelObjectMap;
    public LevelObject[] LevelObjects {get; private set;}

    public Level(Vector2Int size)
    {
        Size = size;
        levelObjectMap = new LevelObject[size.x, size.y];
    }
}
