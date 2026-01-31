public class AttackAction : RoundAction
{
    private int damage;

    public bool TryFindTarget()
    {
        return false;
    }


    public override void Execute(Level level, LevelObject levelObject)
    {
        if (TryFindTarget())
        {
            // Perform attack logic here
        }
    }

    public AttackAction(int damage)
    {
        this.damage = damage;
    }
}