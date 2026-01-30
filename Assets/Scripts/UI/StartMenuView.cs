public class StartMenuView : BaseView
{
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
        // Implement binding logic here
    }
}