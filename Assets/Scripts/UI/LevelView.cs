using System;
using UnityEngine;

/// <summary>
/// 关卡视图 - 管理关卡UI的显示
/// </summary>
public class LevelView : BaseView<LevelViewModel>
{
    private GameObject levelViewGameObjects;
    private GameObject checkerboardGameObject;

    public override void Initialize()
    {
        levelViewGameObjects = new GameObject("Level View GameObject Group");
        checkerboardGameObject = Instantiate(Resources.Load<GameObject>("Prefabs/Checkerboard"), levelViewGameObjects.transform);
        checkerboardGameObject.name = "Checker board";
    }

    public override void BindViewModel(LevelViewModel viewModel)
    {
        base.BindViewModel(viewModel);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    protected override void OnBind()
    {
        if (viewModel != null)
        {
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
            viewModel.LevelModelChanged += OnLevelModelChanged;
            viewModel.Bind();
        }
    }

    protected override void OnUnbind()
    {
        if (viewModel != null)
        {
            viewModel.PropertyChanged -= OnViewModelPropertyChanged;
            viewModel.LevelModelChanged -= OnLevelModelChanged;
            viewModel.Unbind();
        }
    }

    private void OnViewModelPropertyChanged(string propertyName)
    {
        // 根据属性变更更新视图
    }

    private void OnLevelModelChanged(Level level)
    {
        // 当Level模型绑定时调用
        if (level != null)
        {
            Debug.Log($"Level view received level model with size: {level.Size}");
            // 根据Level数据更新视图：为已存在的 LevelObject 创建视图
            foreach (var obj in level.LevelObjects)
            {
                if (obj != null)
                {
                    CreateLevelObjectView(obj);
                }
            }

            // 订阅后续创建的 LevelObject
            level.LevelObjectCreated += OnLevelObjectCreated;
        }
    }

    private void OnLevelObjectCreated(LevelObject levelObject)
    {
        CreateLevelObjectView(levelObject);
    }

    private void CreateLevelObjectView(LevelObject levelObject)
    {
        GameObject viewObject = new GameObject("LevelObjectView");
        // 将 LevelObjectView 挂在 LevelView 的 transform 之下
        viewObject.transform.SetParent(this.transform, false);
        var levelObjectView = viewObject.AddComponent<LevelObjectView>();
        levelObjectView.Initialize();
        levelObjectView.BindLevelObject(levelObject);
    }

    private void OnDestroy()
    {
        OnUnbind();
    }
}