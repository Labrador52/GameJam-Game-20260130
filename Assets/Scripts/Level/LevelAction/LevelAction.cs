public abstract class LevelAction
{
    public int ActionPointCost { get; protected set; }
    public abstract void Execute(Level level, LevelObject levelObject);

    public LevelAction(int actionPointCost)
    {
        ActionPointCost = actionPointCost;
    }
}