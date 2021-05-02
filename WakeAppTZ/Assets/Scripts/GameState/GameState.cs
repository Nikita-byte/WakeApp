using System.Collections.Generic;


public class GameState : BaseState
{
    private GameController _gameController;
    private List<BaseController> _controllers;
    private Counter _counter;

    public GameState(GameController gameController)
    {
        _gameController = gameController;
        _controllers = new List<BaseController>();
        EventManager.Instance.AddListener(EventType.StartGame, OpenGameHud);
    }

    public override void Enter()
    {
        EventManager.Instance.Events[EventType.StartGame].Invoke(EventType.StartGame);
        _controllers.Add(new PlayerController());
        _controllers.Add(new EnemyController());
        _controllers.Add(new FruitController());
        _counter = new Counter();
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
        foreach (BaseController controller in _controllers)
        {
            controller.FixedUpdate();
        }
    }

    public override void LateUpdate()
    {
        foreach (BaseController controller in _controllers)
        {
            controller.LateUpdate();
        }
    }

    public override void Update()
    {
        foreach (BaseController controller in _controllers)
        {
            controller.Update();
        }
    }

    public void OpenGameHud(EventType eventType)
    {
        ScreenInterface.Instance.Execute(PanelType.GamePanel);
    }
}