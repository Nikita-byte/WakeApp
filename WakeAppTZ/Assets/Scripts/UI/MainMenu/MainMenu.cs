using UnityEngine;
using UnityEngine.UI;


public class MainMenu : BasePanel
{
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _recordsBtn;

    public Button NewGameBtn => _newGameBtn;
    public Button Records => _recordsBtn;

    private void OnEnable()
    {
        _newGameBtn.onClick.AddListener(() => StartGame());
        _recordsBtn.onClick.AddListener(() => EventManager.Instance.Events[EventType.Death].Invoke(EventType.Death));
    }

    private void OnDisable()
    {
        _newGameBtn.onClick.RemoveListener(() => StartGame());
        _recordsBtn.onClick.RemoveListener(() => EventManager.Instance.Events[EventType.Death].Invoke(EventType.Death));
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public void StartGame()
    {
        GameObject.FindObjectOfType<GameController>().SetState(StateCreator.Instance.GameState);
    }
}
