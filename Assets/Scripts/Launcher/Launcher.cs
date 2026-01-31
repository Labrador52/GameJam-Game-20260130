using UnityEngine;

public partial class Launcher : MonoBehaviour
{
    private void Awake()
    {
        GameObject ManagerGroup = new GameObject("ManagerGroup");

        GameObject GameManagerGameObject = new GameObject("GameManager");
        GameManagerGameObject.AddComponent<GameManager>();
        GameManagerGameObject.transform.parent = ManagerGroup.transform;

        GameObject LevelManagerGameObject = new GameObject("LevelManager");
        LevelManager levelmanager = LevelManagerGameObject.AddComponent<LevelManager>();
        levelmanager.SetDefaultLevelSize(levelConfig.LevelSize);
        LevelManagerGameObject.transform.parent = ManagerGroup.transform;

        GameObject UIManagerGameObject = new GameObject("UIManager");
        UIManagerGameObject.AddComponent<UIManager>();
        UIManagerGameObject.transform.parent = ManagerGroup.transform;

        InitializeUIViews();
    }

    private void InitializeUIViews()
    {
        GameObject UIGroup = new GameObject("UIGroup");
        foreach (var prefab in BaseViewPrefabs)
        {
            GameObject viewObject = Instantiate(prefab, UIGroup.transform);
            viewObject.name = prefab.name;
            BaseView view = viewObject.GetComponent<BaseView>();
            if (view != null)
            {
                UIManager.Instance.RegisterView(view);
            }
            else
            {
                Debug.LogWarning($"The prefab {prefab.name} does not contain a BaseView component.");
            }
        }
    }
}