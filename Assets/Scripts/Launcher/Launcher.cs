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
        UIManager uIManager = UIManagerGameObject.AddComponent<UIManager>();
        uIManager.ViewPrefabs = ViewPrefabs;
        GameObject UIGroup = new GameObject("UI Group");
        uIManager.InitializeViews(UIGroup.transform);
        UIManagerGameObject.transform.parent = ManagerGroup.transform;

        
    }
}