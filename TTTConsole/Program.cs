using TTTCore;

namespace TTTConsole
{
    public class Program
    {
        private static TTTGame game;
        public static void Main()
        {
            game = new TTTGame();

            char winPlayer = '-';
            (int x, int y) pos;

            while (winPlayer == '-')
            {
                bool isMove = false;
                while (!isMove)
                {
                    Console.Clear();
                    Print();
                    Console.Write($"Player {game.PlayerMove} move x-cord:\t");
                    pos.x = int.Parse(Console.ReadLine()) - 1;
                    Console.Write($"Player {game.PlayerMove} move y-cord:\t");
                    pos.y = int.Parse(Console.ReadLine()) - 1;
                    isMove = game.Move(pos);
                }

                winPlayer = game.Win();
            }


            Console.Clear();
            Print();
            Console.WriteLine($"Player ({winPlayer}) win!!!");
        }

        public static void Print()
        {
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {game.Map[0, 0]} | {game.Map[0, 1]} | {game.Map[0, 2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {game.Map[1, 0]} | {game.Map[1, 1]} | {game.Map[1, 2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {game.Map[2, 0]} | {game.Map[2, 1]} | {game.Map[2, 2]}");
            Console.WriteLine("---+---+---");
        }
    }
}