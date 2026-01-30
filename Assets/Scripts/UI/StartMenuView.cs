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
    }

    protected override void OnBind()
    {
        
    }

    protected override void OnUnbind()
    {
        
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