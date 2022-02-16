using System.Windows.Controls;

namespace TicTacToeMVVM;

public partial class Game : Page
{
    public Game()
    {
        DataContext = Data.GetInstance();
        InitializeComponent();
    }
}