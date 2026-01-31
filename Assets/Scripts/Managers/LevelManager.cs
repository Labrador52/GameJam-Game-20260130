using UnityEngine;

public class LevelManager : SingleInstance<LevelManager>
{
    protected override string GameObjectName => "LevelManager";

    private Vector2Int defaultLevelSize;

    public void SetDefaultLevelSize(Vector2Int size)
    {
        defaultLevelSize = size;
    }

    private Level currentLevel;

    public Level CurrentLevel
    {
        get => currentLevel;
        private set => currentLevel = value;
    }

    public void LoadLevel()
    {
        // 如果未设置默认关卡尺寸，使用 7x7
        if (defaultLevelSize == default(Vector2Int) || defaultLevelSize == Vector2Int.zero)
        {
            defaultLevelSize = new Vector2Int(7, 7);
        }

        CurrentLevel = LevelFactory.CreateLevel(defaultLevelSize);
        GameManager.Instance.SetGameState(GameState.Level);
        // Debug.Log($"Level loaded with size: {CurrentLevel.Size}");

        if (UIManager.Instance.TryGetView<StartMenuView>(out var startMenuView))
        {
            startMenuView.Hide();
        }
        if (UIManager.Instance.TryGetView<LevelView>(out var levelView))
        {
            levelView.Show();
        }

        // 在关卡加载后为LevelViewModel绑定Level模型
        UIManager.Instance.BindLevelModel(CurrentLevel);
    }
}