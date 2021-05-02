using UnityEngine.UI;
using UnityEngine;


public class GamePanel : BasePanel
{
    [SerializeField] private Text _score;

    public void SetScore(string score)
    {
        _score.text = "Score: " + score;
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}