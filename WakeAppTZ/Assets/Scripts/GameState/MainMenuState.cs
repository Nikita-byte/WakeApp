

public class MainMenuState : BaseState
{
    private GameController _gameController;

    public MainMenuState(GameController gameController)
    {
        _gameController = gameController;
        EventManager.Instance.AddListener(EventType.MainMenu, MainMenu);
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void LateUpdate()
    {

    }

    public override void Update()
    {

    }

    public void MainMenu(EventType eventType)
    {
        ScreenInterface.Instance.Execute(PanelType.MainMenu);
    }
}
