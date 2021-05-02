


public class ScreenInterface
{
    public static ScreenInterface Instance = new ScreenInterface();

    private ScreenFactory _screenFactory;
    private BasePanel _currentPanel;

    public ScreenInterface()
    {
        _screenFactory = new ScreenFactory();
    }

    public void Execute(PanelType panelType)
    {
        if (_currentPanel != null)
        {
            _currentPanel.Hide();
        }

        switch (panelType)
        {
            case PanelType.MainMenu:
                _currentPanel = _screenFactory.MainMenu;
                break;
            case PanelType.Records:
                _currentPanel = _screenFactory.RecordPAnel;
                break;
            case PanelType.GamePanel:
                _currentPanel = _screenFactory.GamePanel;
                break;
        }

        _currentPanel.Show();
    }
}
