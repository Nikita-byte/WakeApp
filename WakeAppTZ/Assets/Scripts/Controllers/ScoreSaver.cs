using System.IO;
using UnityEngine;


public class ScoreSaver
{
    private string _path;
    private int _record;
    private RecordsPanel _recordPanel;

    public ScoreSaver()
    { 
        _path = Path.Combine(Application.dataPath, "Record.json");
    }

    public void SetScore(int score)
    {
        if (!File.Exists(_path))
        {
            JSONsave();
        }

        _record = JsonUtility.FromJson<int>(File.ReadAllText(_path));

        if (score >= _record)
        {
            _record = score;
        }

        _recordPanel = GameObject.FindObjectOfType<RecordsPanel>();
        _recordPanel.SetScore(score.ToString());
        _recordPanel.SetRecord(_record.ToString());

        JSONsave();
    }

    private void JSONsave()
    {
        var JSON = JsonUtility.ToJson(_record);
        File.WriteAllText(_path, JSON);
    }
}