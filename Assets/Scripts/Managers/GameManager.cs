using System;
using UnityEngine;

public class GameManager : SingleInstance<GameManager>, IModel
{
	protected override string GameObjectName => "GameManager";

    private GameState currentGameState;


    public Action<GameState, GameState> GameStateChanged;

    public void SetGameState(GameState newState)
    {
        GameState oldState = currentGameState;
        currentGameState = newState;
        GameStateChanged?.Invoke(oldState, newState);
    }

    public new void Initialize()
    {
        currentGameState = GameState.StartMenu;
    }
}

public enum GameState
{
    StartMenu,
    Level
}