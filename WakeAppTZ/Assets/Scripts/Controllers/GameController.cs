using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private BaseState _currentGameState;

    public void SetState(BaseState state)
    {
        if (_currentGameState != null)
        {
            _currentGameState.Exit();
        }

        _currentGameState = state;
        _currentGameState.Enter();
    }

    private void Awake()
    {
        EventManager.Instance.Initialize();

        StateCreator.Instance.SetGameController(this);

        SetState(StateCreator.Instance.MainMenuState);
        ScreenInterface.Instance.Execute(PanelType.MainMenu);
    }

    private void Update()
    {
        _currentGameState.Update();
    }

    private void FixedUpdate()
    {
        _currentGameState.FixedUpdate();
    }

    private void LateUpdate()
    {
        _currentGameState.LateUpdate();
    }
}
