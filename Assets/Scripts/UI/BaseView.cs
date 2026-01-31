using UnityEngine;

/// <summary>
/// 基础视图类 - 所有UI视图的基类
/// </summary>
public abstract class BaseView : MonoBehaviour
{
    public abstract void Initialize();
}

/// <summary>
/// 泛型基础视图类 - 强类型视图模型支持
/// </summary>
public abstract class BaseView<T> : BaseView where T : BaseViewModel
{
    protected T viewModel;
    
    public abstract void Show();
    public abstract void Hide();

    /// <summary>
    /// 绑定视图模型
    /// </summary>
    public virtual void BindViewModel(T viewModel)
    {
        this.viewModel = viewModel;
        OnBind();
    }

    /// <summary>
    /// 获取当前绑定的视图模型
    /// </summary>
    public T GetViewModel()
    {
        return viewModel;
    }

    /// <summary>
    /// 视图绑定时调用 - 订阅事件和初始化数据绑定
    /// </summary>
    protected abstract void OnBind();

    /// <summary>
    /// 视图解绑时调用 - 取消订阅事件
    /// </summary>
    protected abstract void OnUnbind();
}