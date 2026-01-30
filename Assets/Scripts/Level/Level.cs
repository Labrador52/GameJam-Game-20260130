using UnityEngine;

public class Level
{
    public Vector2Int Size {get; set;}
    public int RoundCount {get; private set;}
    public int ActionPointCurrent {get; private set;}
    public int ActionPointMax {get; private set;}
    public LevelObject[] LevelObjects {get; private set;}
}
