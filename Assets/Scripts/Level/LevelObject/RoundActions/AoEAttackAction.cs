using System.Threading;
using UnityEngine;

public class AoEAttackAction : RoundAction
{
    private static readonly Vector2Int[] vector2IntOffsets = new Vector2Int[]
    {
        new Vector2Int(-1, 1),
        new Vector2Int(0, 1),
        new Vector2Int(1, 1),
        new Vector2Int(-1, 0),
        new Vector2Int(1, 0),
        new Vector2Int(-1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(1, -1),
    };

    private int damage;
    public override void Execute(Level level, LevelObject levelObject)
    {
        if (level != null)
        {
            foreach (var offset in vector2IntOffsets)
            {
                Vector2Int targetPosition = levelObject.Position + offset;
                if (level.TryGetLevelObjectAtPosition(targetPosition, out LevelObject targetLevelObject))
                {
                    RoundActionExecuted?.Invoke();
                    targetLevelObject.TakeDamage(damage);
                }
            }
        }
    }

    public AoEAttackAction(int damage)
    {
        this.damage = damage;
    }
}