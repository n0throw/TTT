using System.Windows;

namespace TicTacToeMVVM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = Data.GetInstance();
        InitializeComponent();
    }
}