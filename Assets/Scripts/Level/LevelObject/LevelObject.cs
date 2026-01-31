using System;
using UnityEngine;

public class LevelObject
{
    private readonly Level level;
    public Vector2Int Position { get; set; }
    public int HitPointCurrent { get; private set; }
    public int HitPointMax { get; private set; }
    public int Speed { get; private set; }
    public bool IsMasked { get; private set; }
    
    public RoundAction RoundAction { get; set; }

    public Action RoundActionExecuted;

    public void SetRoundAction(RoundAction roundAction)
    {
        if (RoundAction != null)
        {
            RoundAction.RoundActionExecuted -= () => RoundActionExecuted?.Invoke();
        }
        roundAction.RoundActionExecuted += () => RoundActionExecuted?.Invoke();
        RoundAction = roundAction;
    }

    public void StartRoundAction(Level level)
    {
        RoundAction?.Execute(level, this);
    }

    public void TakeDamage(int damage)
    {
        HitPointCurrent -= damage;
        if (HitPointCurrent < 0)
        {
            HitPointCurrent = 0;
        }
    }

    public void TakeHeal(int heal)
    {
        HitPointCurrent += heal;
        if (HitPointCurrent > HitPointMax)
        {
            HitPointCurrent = HitPointMax;
        }
    }

    public void SetPosition(Vector2Int newPosition)
    {
        Position = newPosition;
        PositionChanged?.Invoke(newPosition);
    }

    public Action<Vector2Int> PositionChanged;

    public LevelObject(Level level, int hitPointMax, int speed)
    {
        this.level = level;
        HitPointMax = hitPointMax;
        HitPointCurrent = hitPointMax;
        Speed = speed;
    }
}