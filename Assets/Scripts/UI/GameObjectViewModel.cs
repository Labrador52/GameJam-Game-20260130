/// <summary>
/// 游戏对象视图模型
/// </summary>
public class GameObjectViewModel : BaseViewModel
{
    private IModel model;

    /// <summary>
    /// 绑定Model数据
    /// </summary>
    public void BindModel(IModel model)
    {
        this.model = model;
    }

    public override void Initialize()
    {
        // 初始化逻辑
    }

    public override void Bind()
    {
        base.Bind();
        // 订阅Model变更事件等
    }

    public override void Unbind()
    {
        base.Unbind();
        // 取消订阅事件
    }
}