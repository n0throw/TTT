using System.Windows.Controls;

namespace TicTacToeMVVM;

public partial class Settings : Page
{
    public Settings()
    {
        DataContext = Data.GetInstance();
        InitializeComponent();
    }
}