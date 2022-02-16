using System.Windows;

namespace TicTacToeMVVM;

public class Data : MVVMBase
{
    private static Data instance;

    private Data()
    {
        SettingsData = new();
        GameData = new();
        currentPage = @"MainMenu.xaml";
    }

    public static Data GetInstance()
    {
        if (instance == null)
            instance = new Data();
        return instance;
    }

    private SettingsData settingsData;
    private GameData gameData;
    public SettingsData SettingsData
    {
        get => settingsData;
        set
        {
            settingsData = value;
            OnPropertyChanged("SettingsData");
        }
    }

    public GameData GameData
    {
        get => gameData;
        set
        {
            gameData = value;
            OnPropertyChanged("GameData");
        }
    }

    private string currentPage;
    public string CurrentPage
    {
        get => currentPage;
        set
        {
            currentPage = value;
            OnPropertyChanged("CurrentPage");
        }
    }

    private RelayCommand setGamePage;
    public RelayCommand SetGamePage
    {
        get => setGamePage ??= new RelayCommand(obj =>
        {
            CurrentPage = "Game.xaml";
            if (GameData.GameGridVisibility == Visibility.Hidden)
                GameData = new();
        });
    }

    private RelayCommand setSettingsPage;
    public RelayCommand SetSettingsPage
    {
        get => setSettingsPage ??= new RelayCommand(obj => CurrentPage = "Settings.xaml");
    }

    private RelayCommand setMainMenuPage;
    public RelayCommand SetMainMenuPage
    {
        get => setMainMenuPage ??= new RelayCommand(obj => CurrentPage = "MainMenu.xaml");
    }
}
