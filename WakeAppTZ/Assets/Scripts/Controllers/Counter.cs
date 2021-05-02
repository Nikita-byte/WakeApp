using UnityEngine;


public class Counter 
{
    private GamePanel _gamepanel;
    private ScoreSaver _scoreSaver;
    private int _gamescore;

    public int GameScore => _gamescore;

    public Counter()
    {
        _scoreSaver = new ScoreSaver();
        _gamescore = 0;
        _gamepanel = GameObject.FindObjectOfType<GamePanel>();

        EventManager.Instance.AddListener(EventType.GetFruit, SetScore);
        EventManager.Instance.AddListener(EventType.Death, SaveScore);
    }

    private void SetScore(EventType eventType)
    {
        _gamescore += 1;
        _gamepanel.SetScore(_gamescore.ToString());
    }

    private void SaveScore(EventType eventType)
    {
        _scoreSaver.SetScore(_gamescore);
    }
}
