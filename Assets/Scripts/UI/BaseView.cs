using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    public abstract void Initialize();
}

public abstract class BaseView<T> : BaseView where T : BaseViewModel
{
    private T viewModel;
    public abstract void Show();
    public abstract void Hide();

    public virtual void BindViewModel(T viewModel)
    {
        this.viewModel = viewModel;
        OnBind();
    }
    protected abstract void OnBind();
    protected abstract void OnUnbind();
    
}