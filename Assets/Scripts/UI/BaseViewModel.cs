using System;

public abstract class BaseViewModel
{
    public abstract void Initialize();

    /// <summary>
    /// 绑定视图，订阅事件和初始化数据绑定
    /// </summary>
    public virtual void Bind()
    {
    }

    /// <summary>
    /// 解绑视图，取消订阅事件
    /// </summary>
    public virtual void Unbind()
    {
    }

    /// <summary>
    /// 属性变更通知事件
    /// </summary>
    public event Action<string> PropertyChanged;

    /// <summary>
    /// 触发属性变更通知
    /// </summary>
    protected void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(propertyName);
    }
}