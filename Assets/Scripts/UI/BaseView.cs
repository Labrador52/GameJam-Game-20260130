using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    public abstract void Show();
    public abstract void Hide();

    public abstract void BindViewModel(BaseViewModel viewModel);
    protected abstract void OnBind();
    protected abstract void OnUnbind();
    
}