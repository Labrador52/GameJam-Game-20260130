using System;

public class StartMenuView : BaseView
{
    private StartMenuViewModel startMenuViewModel;
    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void BindViewModel(BaseViewModel viewModel)
    {
        startMenuViewModel = viewModel as StartMenuViewModel;
        OnBind();
    }

    protected override void OnBind()
    {
        startMenuViewModel.NotifyStartMenuShown += OnStartMenuShown;
        startMenuViewModel.NotifyStartMenuHidden += OnStartMenuHidden;
    }

    protected override void OnUnbind()
    {
        startMenuViewModel.NotifyStartMenuShown -= OnStartMenuShown;
        startMenuViewModel.NotifyStartMenuHidden -= OnStartMenuHidden;
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
        startMenuViewModel?.StartGameButtonClicked();
    }

    #endregion
}