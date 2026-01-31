using System;

public class StartMenuViewModel : BaseViewModel
{
    private GameManager gameManager;

    public override void Initialize()
    {
        gameManager = GameManager.Instance;
        Bind();
    }

    public void Bind()
    {
        gameManager.GameStateChanged += OnGameStateChanged;
    }

    public void Unbind()
    {
        gameManager.GameStateChanged -= OnGameStateChanged;
    }

    public void StartGameButtonClicked()
    {
        LevelManager.Instance.LoadLevel();
    }

    private void OnGameStateChanged(GameState oldState, GameState newState)
    {
        if (newState == GameState.StartMenu)
        {
            NotifyStartMenuShown?.Invoke();
        }
        else if (oldState == GameState.StartMenu)
        {
            NotifyStartMenuHidden?.Invoke();
        }
    }

    public Action NotifyStartMenuShown;
    public Action NotifyStartMenuHidden;
    
}