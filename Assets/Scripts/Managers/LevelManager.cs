using UnityEngine;

public class LevelManager : SingleInstance<LevelManager>
{
    protected override string GameObjectName => "LevelManager";

    private Level currentLevel;

    public Level CurrentLevel
    {
        get => currentLevel;
        private set => currentLevel = value;
    }

    public Level CreateLevel()
    {
        return default;
    }
}