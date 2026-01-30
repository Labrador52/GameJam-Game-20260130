using System.Collections.Generic;

public class UIManager : SingleInstance<UIManager>
{
    protected override string GameObjectName => "UIManager";

    private readonly Dictionary<System.Type, BaseView> viewTypeDictionary = new Dictionary<System.Type, BaseView>();
    private readonly Dictionary<System.Type, BaseViewModel> viewModelTypeDictionary = new Dictionary<System.Type, BaseViewModel>();

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

    public void RegisterViewModel(BaseViewModel viewModel)
    {
        var type = viewModel.GetType();
        if (!viewModelTypeDictionary.ContainsKey(type))
        {
            viewModelTypeDictionary[type] = viewModel;
        }
        else
        {
            UnityEngine.Debug.LogWarning($"ViewModel of type {type} is already registered.");
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

    public bool TryGetViewModel<T>(out T viewModel) where T : BaseViewModel
    {
        var type = typeof(T);
        if (viewModelTypeDictionary.TryGetValue(type, out BaseViewModel baseViewModel))
        {
            viewModel = baseViewModel as T;
            return true;
        }
        else
        {
            viewModel = null;
            return false;
        }
    }

    public T GetViewModel<T>() where T : BaseViewModel
    {
        var type = typeof(T);
        if (viewModelTypeDictionary.TryGetValue(type, out BaseViewModel viewModel))
        {
            return viewModel as T;
        }
        else
        {
            UnityEngine.Debug.LogError($"ViewModel of type {type} is not registered.");
            return null;
        }
    }
    
}