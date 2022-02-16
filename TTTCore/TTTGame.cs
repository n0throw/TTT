namespace TTTCore
{
    public class TTTGame
    {
        private bool isXMove = true; 
        public char PlayerMove
        {
            get => isXMove ? 'X' : 'O';
        }

        public char[,] Map { get; set; } = new char[3, 3]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
        };

        public bool Move((int x, int y) pos)
        {
            if (Map[pos.y, pos.x] == ' ')
            {
                Map[pos.y, pos.x] = PlayerMove;

                isXMove = !isXMove;

                return true;
            }

            return false;
        }

        public char Win()
        {
            int sum, sum2;
            // horizontal
            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += Map[i, j];
                }

                if (sum % 'X' == 0)
                    return 'X';
                else if (sum % 'O' == 0)
                    return 'O';
            }

            // vertical
            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += Map[j, i];
                }

                if (sum % 'X' == 0)
                    return 'X';
                else if (sum % 'O' == 0)
                    return 'O';
            }

            // \ - state
            sum = 0;
            sum2 = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += Map[i, i];
                sum2 += Map[i, 2 - i];
            }

            if (sum % 'X' == 0 || sum2 % 'X' == 0)
                return 'X';
            if (sum % 'O' == 0 || sum2 % 'O' == 0)
                return 'O';

            return '-';
        }
    }
}