using UnityEngine.UI;
using UnityEngine;


public class ScreenFactory
{
    private GameObject _canvas;
    private MainMenu _mainMenu;
    private RecordsPanel _recordsPanel;
    private GamePanel _gamePanel;

    public ScreenFactory()
    {
        if (_canvas == null)
        {
            GameObject go = Resources.Load<GameObject>("UI/Canvas");
            _canvas = GameObject.Instantiate(go);
            _canvas.gameObject.SetActive(true);
        }
    }

    public MainMenu MainMenu
    {
        get
        {
            if (_mainMenu == null)
            {
                _canvas.gameObject.SetActive(true);
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("UI/MainMenu"), _canvas.transform.position, Quaternion.identity, _canvas.transform);
                _mainMenu = go.GetComponent<MainMenu>();
            }
            return _mainMenu;
        }
    }

    public RecordsPanel RecordPAnel
    {
        get
        {
            if (_recordsPanel == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("UI/RecordPanel"), _canvas.transform);
                _recordsPanel = go.GetComponent<RecordsPanel>();
            }
                
            return _recordsPanel;
        }
    }

    public GamePanel GamePanel
    {
        get
        {
            if (_gamePanel == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("UI/GamePanel"), _canvas.transform);
                _gamePanel = go.GetComponent<GamePanel>();
            }
                
            return _gamePanel;
        }
    }
}
