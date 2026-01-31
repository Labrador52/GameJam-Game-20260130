using System;
using UnityEngine;

/// <summary>
/// 开始菜单视图 - 处理开始菜单UI
/// </summary>
public class StartMenuView : BaseView<StartMenuViewModel>
{
    public override void Initialize()
    {
        
    }
    
    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void BindViewModel(StartMenuViewModel viewModel)
    {
        base.BindViewModel(viewModel);
    }

    protected override void OnBind()
    {
        if (viewModel != null)
        {
            viewModel.NotifyStartMenuShown += OnStartMenuShown;
            viewModel.NotifyStartMenuHidden += OnStartMenuHidden;
            viewModel.Bind();
        }
    }

    protected override void OnUnbind()
    {
        if (viewModel != null)
        {
            viewModel.NotifyStartMenuShown -= OnStartMenuShown;
            viewModel.NotifyStartMenuHidden -= OnStartMenuHidden;
            viewModel.Unbind();
        }
    }

    private void OnDestroy()
    {
        OnUnbind();
    }

    #region View Callbacks

    private void OnStartMenuShown()
    {
        Show();
    }

    private void OnStartMenuHidden()
    {
        Hide();
    }

    #endregion

    #region View Events

    public void StartGameButtonClicked()
    {
        Debug.Log("Start Game Button Clicked in View");
        viewModel?.StartGameButtonClicked();
    }

    #endregion
}