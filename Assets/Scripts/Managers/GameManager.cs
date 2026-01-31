using System;
using UnityEngine;

public class GameManager : SingleInstance<GameManager>, IModel
{
	protected override string GameObjectName => "GameManager";

    private GameState currentGameState;


    public Action<GameState, GameState> GameStateChanged;

    public void SetGameState(GameState newState)
    {
        // GameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    StartMenu,
    Level
}