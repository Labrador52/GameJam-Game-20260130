using System.Collections.Generic;

public class UIManager : SingleInstance<UIManager>
{
    protected override string GameObjectName => "UIManager";

    // Add UIManager specific methods and properties here
    public readonly List<BaseView> views = new List<BaseView>();
    
}