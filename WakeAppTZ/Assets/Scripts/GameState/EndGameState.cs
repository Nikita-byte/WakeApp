using UnityEngine;


public class EndGameState : BaseState
{
    private GameController _gameController;

    public EndGameState(GameController gameController)
    {
        _gameController = gameController;
        EventManager.Instance.AddListener(EventType.Death, new System.Action<EventType>(OpenRecords));
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

    public void OpenRecords(EventType eventType)
    {
        ScreenInterface.Instance.Execute(PanelType.Records);
        _gameController.SetState(StateCreator.Instance.EndGameState);
    }
}
