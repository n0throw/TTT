using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeMVVM;
public partial class MainMenu : Page
{
    private static readonly Random rand = new();

    public MainMenu()
    {
        InitializeComponent();
        DataContext = Data.GetInstance();
        Loaded += MainMenu_Loaded;
    }

    private void MainMenu_Loaded(object sender, RoutedEventArgs e)
    {
        BackGround.Children.Clear();
        int countEl = AddRowAndColumn();
        AddBorder(countEl);
        AddButton(countEl);
    }

    private int AddRowAndColumn(int size = 50)
    {

        int count = 4000 / size;

        for (int i = 0; i < count; i++)
        {
            BackGround.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(size) });
            BackGround.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(size) });
        }

        return count;
    }

    private void AddBorder(int count)
    {
        Border border;

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                border = new()
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = new SolidColorBrush(Colors.Gray),
                };

                border.SetValue(Grid.RowProperty, i);
                border.SetValue(Grid.ColumnProperty, j);

                BackGround.Children.Add(border);
            }
        }
    }

    private void AddButton(int count)
    {
        Button button;

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                button = new()
                {
                    Content = GetRandomSymbol(),
                    FontSize = 25
                };
                button.SetValue(Grid.RowProperty, i);
                button.SetValue(Grid.ColumnProperty, j);

                BackGround.Children.Add(button);
            }
        }
    }

    private static char GetRandomSymbol() => rand.Next(3) switch
    {
        0 => 'X',
        1 => 'O',
        _ => ' ',
    };
}