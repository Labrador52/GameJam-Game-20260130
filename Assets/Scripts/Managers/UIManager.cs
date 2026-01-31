using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI管理器 - 管理所有UI视图的生命周期和初始化
/// </summary>
public class UIManager : SingleInstance<UIManager>
{
    protected override string GameObjectName => "UIManager";

    public GameObject[] ViewPrefabs;

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
            Debug.LogWarning($"View of type {type} is already registered.");
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
        view = null;
        return false;
    }

    /// <summary>
    /// 初始化所有视图和其对应的视图模型
    /// </summary>
    public void InitializeViews(Transform parent = null)
    {
        if (ViewPrefabs != null)
        {
            foreach (var prefab in ViewPrefabs)
            {
                GameObject viewObject = Instantiate(prefab, parent);
                viewObject.name = prefab.name;
                BaseView view = viewObject.GetComponent<BaseView>();
                view.Initialize();

                if (view != null)
                {
                    RegisterView(view);
                    CreateAndBindViewModel(view);
                }
                else
                {
                    Debug.LogWarning($"The prefab {prefab.name} does not contain a BaseView component.");
                }
            }
        }
        else
        {
            Debug.LogWarning("ViewPrefabs is null or empty.");
        }
    }

    /// <summary>
    /// 为视图创建并绑定相应的视图模型
    /// </summary>
    private void CreateAndBindViewModel(BaseView view)
    {
        if (view is StartMenuView startMenuView)
        {
            var viewModel = new StartMenuViewModel();
            viewModel.Initialize();
            startMenuView.BindViewModel(viewModel);
        }
        else if (view is LevelView levelView)
        {
            var viewModel = new LevelViewModel();
            viewModel.Initialize();
            levelView.BindViewModel(viewModel);
        }
        else if (view is GameObjectView gameObjectView)
        {
            var viewModel = new GameObjectViewModel();
            viewModel.Initialize();
            gameObjectView.BindViewModel(viewModel);
        }
    }

    /// <summary>
    /// 为LevelViewModel绑定Level模型 - 在关卡加载后调用
    /// </summary>
    public void BindLevelModel(Level levelModel)
    {
        if (TryGetView<LevelView>(out var levelView))
        {
            var levelViewModel = levelView.GetViewModel();
            if (levelViewModel != null && !levelViewModel.HasLevelModel)
            {
                levelViewModel.BindLevelModel(levelModel);
                Debug.Log("Level model bound to LevelViewModel successfully.");
            }
        }
    }
}
