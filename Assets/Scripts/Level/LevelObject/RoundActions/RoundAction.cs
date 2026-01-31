using System;

public abstract class RoundAction
{
    public Action RoundActionExecuted;
    public abstract void Execute(Level level, LevelObject levelObject);
}