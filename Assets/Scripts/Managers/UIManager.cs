using System.Collections.Generic;

public class UIManager : SingleInstance<UIManager>
{
    protected override string GameObjectName => "UIManager";

    private readonly Dictionary<System.Type, BaseView> viewTypeDictionary = new Dictionary<System.Type, BaseView>();

    public void RegisterView(BaseView view)
    {
        var type = view.GetType();
        if (!viewTypeDictionary.ContainsKey(type))
        {
            viewTypeDictionary[type] = view;
        }
        else
        {
            UnityEngine.Debug.LogWarning($"View of type {type} is already registered.");
        }
    }

    public bool TryGetView<T>(out T view) where T : BaseView
    {
        var type = typeof(T);
        if (viewTypeDictionary.TryGetValue(type, out BaseView baseView))
        {
            view = baseView as T;
            return true;
        }
        else
        {
            view = null;
            return false;
        }
    }

    public T GetView<T>() where T : BaseView
    {
        var type = typeof(T);
        if (viewTypeDictionary.TryGetValue(type, out BaseView view))
        {
            return view as T;
        }
        else
        {
            UnityEngine.Debug.LogError($"View of type {type} is not registered.");
            return null;
        }
    }
    
}