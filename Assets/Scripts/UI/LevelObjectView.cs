using UnityEngine;

/// <summary>
/// 关卡元素的场景视图（作为 LevelView 的子视图）
/// </summary>
public class LevelObjectView : GameObjectView
{
    private LevelObject levelObjectModel;

    public override void Initialize()
    {
        gameObject.name = "LevelObjectView";
        // 尝试加载并实例化 CoreGameObject 预制体（路径: Resources/prefabs/CoreGameObject）
        var prefab = Resources.Load<GameObject>("prefabs/CoreGameObject");
        if (prefab != null)
        {
            var go = Object.Instantiate(prefab, this.transform);
            go.name = "CoreGameObject";
        }
        else
        {
            // 若没有找到预制体则保持空占位
        }
    }

    /// <summary>
    /// 绑定 LevelObject 模型到视图
    /// </summary>
    public void BindLevelObject(LevelObject levelObject)
    {
        if (levelObjectModel != null)
        {
            levelObjectModel.PositionChanged -= OnPositionChanged;
        }

        levelObjectModel = levelObject;
        if (levelObjectModel != null)
        {
            levelObjectModel.PositionChanged += OnPositionChanged;
            // 初始化位置
            OnPositionChanged(levelObjectModel.Position);
        }
    }

    private void OnPositionChanged(Vector2Int newPosition)
    {
        // 将格子坐标映射为世界坐标（简单映射：x -> x, y -> z）
        transform.localPosition = new Vector3(newPosition.x, 0f, newPosition.y);
    }

    protected override void OnBind()
    {
        // 保持与父类行为一致
        base.OnBind();
    }

    protected override void OnUnbind()
    {
        if (levelObjectModel != null)
        {
            levelObjectModel.PositionChanged -= OnPositionChanged;
            levelObjectModel = null;
        }
        base.OnUnbind();
    }

    private void OnDestroy()
    {
        OnUnbind();
    }
}
