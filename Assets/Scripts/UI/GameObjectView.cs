using UnityEngine;

/// <summary>
/// 游戏对象视图
/// </summary>
public class GameObjectView : BaseView<GameObjectViewModel>
{
    private GameObjectViewModel gameObjectViewModel;

    public GameObject checkerboardGameObject;

    public override void Initialize()
    {
        // 初始化视图
    }

    public override void BindViewModel(GameObjectViewModel viewModel)
    {
        gameObjectViewModel = viewModel;
        OnBind();
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    protected override void OnBind()
    {
        if (gameObjectViewModel != null)
        {
            gameObjectViewModel.PropertyChanged += OnViewModelPropertyChanged;
            gameObjectViewModel.Bind();
        }
    }

    protected override void OnUnbind()
    {
        if (gameObjectViewModel != null)
        {
            gameObjectViewModel.PropertyChanged -= OnViewModelPropertyChanged;
            gameObjectViewModel.Unbind();
        }
    }

    private void OnViewModelPropertyChanged(string propertyName)
    {
        // 根据属性变更更新视图
    }

    private void OnDestroy()
    {
        OnUnbind();
    }
}