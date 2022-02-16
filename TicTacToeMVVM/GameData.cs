using System.Collections.ObjectModel;
using System.Windows;

namespace TicTacToeMVVM;

public class GameData : MVVMBase
{
    public GameData()
    {
        Map = new ObservableCollection<char>()
            {
                ' ', ' ', ' ',
                ' ', ' ', ' ',
                ' ', ' ', ' '
            };

        PlayerMove = 'X';
        GameGridVisibility = Visibility.Visible;
    }

    private Visibility gameGridVisibility;

    public Visibility GameGridVisibility
    {
        get => gameGridVisibility;
        set
        {
            gameGridVisibility = value;
            OnPropertyChanged("GameGridVisibility");
        }
    }

    private char playerMove;
    public char PlayerMove
    {
        get => playerMove;
        set
        {
            playerMove = value;
            OnPropertyChanged("PlayerMove");
        }
    }

    public ObservableCollection<char> Map { get; set; }

    private RelayCommand move;
    public RelayCommand Move
    {
        get => move ??= new RelayCommand(obj =>
        {
            int index = int.Parse((string)obj);
            if (Map[index] == ' ')
            {
                Map[index] = PlayerMove;

                if (Win() != '-')
                    GameGridVisibility = Visibility.Hidden;
                else
                    PlayerMove = PlayerMove == 'X' ? 'O' : 'X';
            }
        });
    }

    private char Win()
    {
        int sum;
        // horizontal
        for (int i = 0; i < 8; i += 3)
        {
            sum = 0;
            for (int j = 0; j < 3; j++)
                sum += Map[i + j];

            if (sum % 'X' == 0)
                return 'X';
            else if (sum % 'O' == 0)
                return 'O';
        }

        // vertical
        for (int i = 0; i < 3; i++)
        {
            sum = 0;
            for (int j = 0; j < 8; j += 3)
            {
                sum += Map[i + j];
            }

            if (sum % 'X' == 0)
                return 'X';
            else if (sum % 'O' == 0)
                return 'O';
        }

        // \ - state
        sum = 0;
        for (int i = 0; i < 9; i += 4)
            sum += Map[i];

        if (sum % 'X' == 0)
            return 'X';
        else if (sum % 'O' == 0)
            return 'O';

        sum = 0;
        for (int i = 2; i < 7; i += 2)
            sum += Map[i];

        if (sum % 'X' == 0)
            return 'X';
        else if (sum % 'O' == 0)
            return 'O';

        sum = 0;
        for (int i = 0; i < 8; i++)
            if (Map[i] != ' ')
                sum++;

        if (sum == 8)
        {
            PlayerMove = ' ';
            return 'n';
        }

        return '-';
    }
}