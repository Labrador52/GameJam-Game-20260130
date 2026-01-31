using System;
using System.Diagnostics;

/// <summary>
/// 开始菜单视图模型 - 处理开始菜单的业务逻辑
/// </summary>
public class StartMenuViewModel : BaseViewModel
{
    private GameManager gameManager;

    /// <summary>
    /// 开始菜单显示事件
    /// </summary>
    public Action NotifyStartMenuShown;

    /// <summary>
    /// 开始菜单隐藏事件
    /// </summary>
    public Action NotifyStartMenuHidden;

    public override void Initialize()
    {
        gameManager = GameManager.Instance;
    }

    public override void Bind()
    {
        base.Bind();
        if (gameManager != null)
        {
            gameManager.GameStateChanged += OnGameStateChanged;
        }
    }

    public override void Unbind()
    {
        base.Unbind();
        if (gameManager != null)
        {
            gameManager.GameStateChanged -= OnGameStateChanged;
        }
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
}