using System;

public class StartMenuViewModel : BaseViewModel
{
    private GameManager gameManager;

    public override void Initialize()
    {
        gameManager = GameManager.Instance;
    }

    public void StartGameButtonClicked()
    {
        // gameManager.StartGame();
    }
    
}