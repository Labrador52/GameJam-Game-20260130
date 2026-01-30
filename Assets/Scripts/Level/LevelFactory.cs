using System.Numerics;
using UnityEngine;

public static class LevelFactory
{
    public static Level CreateLevel(Vector2Int size)
    {
        Level level = new Level(size);
        return level;
    }
}