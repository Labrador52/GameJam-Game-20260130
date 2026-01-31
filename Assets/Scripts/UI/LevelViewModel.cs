public class LevelViewModel : BaseViewModel
{
    private Level levelModel;
    public override void Initialize()
    {
        if (LevelManager.Instance.CurrentLevel != null)
        {
            levelModel = LevelManager.Instance.CurrentLevel;
        }
        else
        {
            throw new System.Exception("No current level found in LevelManager.");
        }
    }
}