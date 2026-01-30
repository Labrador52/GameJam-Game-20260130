using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    public Vector2Int LevelSize;
}