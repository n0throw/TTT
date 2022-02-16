using System.Windows;
using System.Windows.Controls;
using TTTCore;

namespace TicTacToe;

public partial class MainWindow : Window
{
    private static TTTGame game;
    private static bool isWin;
    public MainWindow()
    {
        game = new TTTGame();
        DataContext = game;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (isWin)
            MessageBox.Show($"The player won {(game.PlayerMove == 'O' ? 'X' : 'O')}");
        else if (game.Move(GetPos(((Button)sender).Uid)))
        {
            ((Button)sender).Content = game.PlayerMove == 'O' ? 'X' : 'O';
            PlayerMove.Text = $"Player Move: {game.PlayerMove}";
            CheckWin();
        }
    }

    private void NewGame_Click(object sender, RoutedEventArgs e) => StartNewGame();

    private void StartNewGame()
    {
        game = new TTTGame();
        isWin = false;
        PlayerWin.Visibility = Visibility.Hidden;
        PlayerMove.Text = $"Player Move: {game.PlayerMove}";

        foreach (Button item in TTTGrid.Children)
        {
            item.Content = string.Empty;
        }
    }

    private void CheckWin()
    {
        char winPlayer = game.Win();

        if (winPlayer != '-')
        {
            PlayerWin.Visibility = Visibility.Visible;
            PlayerWin.Text = $"The player won {winPlayer}";
            isWin = true;
        }
    }
    private static (int, int) GetPos(string pos) => (int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()));
}
