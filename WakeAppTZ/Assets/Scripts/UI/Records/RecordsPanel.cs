using UnityEngine.UI;
using UnityEngine;


public class RecordsPanel : BasePanel
{
    [SerializeField] private Text _record;
    [SerializeField] private Text _yourPoints;

    public Button Exit;

    public void SetScore(string score)
    {
        _yourPoints.text = "Score: " + score;
    }

    public void SetRecord(string score)
    {
        _record.text = score;
    }

    private void OnEnable()
    {
        Exit.onClick.AddListener(() => EndGame());
    }

    private void OnDisable()
    {
        Exit.onClick.RemoveListener(() => EndGame());
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
