using System;

/// <summary>
/// 关卡视图模型 - 处理关卡数据和视图之间的交互
/// </summary>
public class LevelViewModel : BaseViewModel
{
    private Level levelModel;

    /// <summary>
    /// Level模型变更事件
    /// </summary>
    public event Action<Level> LevelModelChanged;

    /// <summary>
    /// 绑定Level模型数据
    /// </summary>
    public void BindLevelModel(Level level)
    {
        if (level == null)
        {
            throw new System.Exception("Cannot bind null Level model to LevelViewModel.");
        }

        levelModel = level;
        NotifyPropertyChanged(nameof(levelModel));
        LevelModelChanged?.Invoke(levelModel);
    }

    /// <summary>
    /// 获取当前绑定的Level模型
    /// </summary>
    public Level GetLevelModel()
    {
        return levelModel;
    }

    /// <summary>
    /// 检查是否已绑定Level
    /// </summary>
    public bool HasLevelModel => levelModel != null;

    public override void Initialize()
    {
        // Initialize时不绑定Level，由外部在合适的时机调用BindLevelModel
    }

    public override void Bind()
    {
        base.Bind();
        // 如果已有模型，可以在此订阅其事件
        if (levelModel != null)
        {
            // 订阅Level的事件
        }
    }

    public override void Unbind()
    {
        base.Unbind();
        // 取消订阅事件
        levelModel = null;
    }
}