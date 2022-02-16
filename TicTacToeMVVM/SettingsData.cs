namespace TicTacToeMVVM;

public class SettingsData : MVVMBase
{
    private RelayCommand prevLang;
    public RelayCommand PrevLang
    {
        get => prevLang ??= new RelayCommand(obj =>
        {
            int index = App.Languages.IndexOf(App.Language);

            if (index == App.Languages.Count - 1)
                App.Language = App.Languages[0];
            else
                App.Language = App.Languages[++index];
        });
    }

    private RelayCommand nextLang;
    public RelayCommand NextLang
    {
        get => nextLang ??= new RelayCommand(obj =>
        {
            int index = App.Languages.IndexOf(App.Language);

            if (index == 0)
                App.Language = App.Languages[^1];
            else
                App.Language = App.Languages[--index];
        });
    }
}