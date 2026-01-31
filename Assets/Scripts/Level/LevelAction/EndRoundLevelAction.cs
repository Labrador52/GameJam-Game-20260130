public class EndRoundLevelAction : LevelAction
{

    public override void Execute(Level level, LevelObject levelObject)
    {
        level.ExecuteRound();
    }
    public EndRoundLevelAction(int actionPointCost = 0) : base(actionPointCost)
    {
        
    }
}