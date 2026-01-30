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
        CurrentLevel = LevelFactory.CreateLevel(defaultLevelSize);
        GameManager.Instance.SetGameState(GameState.Level);
        Debug.Log($"Level loaded with size: {CurrentLevel.Size}");
    }
}