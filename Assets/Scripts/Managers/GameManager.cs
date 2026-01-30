using System;
using UnityEngine;

public class GameManager : SingleInstance<GameManager>, IModel
{
	protected override string GameObjectName => "GameManager";

    public Action<GameState> GameStateChanged;

    private void SetGameState(GameState newState)
    {
        GameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    StartMenu,
    Level
}