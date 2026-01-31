using System;

public class StartMenuView : BaseView<StartMenuViewModel>
{
    private StartMenuViewModel startMenuViewModel;

    public override void Initialize()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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