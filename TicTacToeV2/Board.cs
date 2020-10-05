namespace TicTacToe
{
    class Board
    {
        private Symbol[,] symbols;

        private Row[] Rows { get; set; }

        private Column[] Columns { get; set; }

        private Diagonal[] Diagonals { get; set; }

        public Symbol this[int row, int col]
        {
            get => symbols[row, col];
            set => symbols[row, col] = value;
        }

        public Board()
        {
            symbols = new Symbol[3, 3];
            Rows = new[] {
                new Row(this, 0),
                new Row(this, 1),
                new Row(this, 2)
            };
            Columns = new[] {
                new Column(this, 0),
                new Column(this, 1),
                new Column(this, 2)
            };
            Diagonals = new[] {
                new Diagonal(this, Direction.DownRight),
                new Diagonal(this, Direction.DownLeft)
            };
        }


        public void Draw()
        {
            System.Console.WriteLine("  1 2 3");
            System.Console.WriteLine(" =======");
            for (int row = 0; row < 3; ++row)
            {
                System.Console.Write($"{row + 1}|");
                for (int col = 0; col < 3; ++col)
                {
                    System.Console.Write(symbols[row, col] switch
                    {
                        Symbol.Circle => "O",
                        Symbol.Cross => "X",
                        _ => " ",
                    } + "|");
                }
                System.Console.WriteLine();
                System.Console.WriteLine(" -------");
            }
        }

        public bool Full()
        {
            for (int r = 0; r < symbols.GetLength(0); ++r)
            {
                for (int c = 0; c < symbols.GetLength(1); ++c)
                {
                    if (this[r, c] == Symbol.Blank)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool HasCompleteLine()
        {
            return
                Rows[0].Complete || 
                Rows[1].Complete || 
                Rows[2].Complete ||
                Columns[0].Complete || 
                Columns[1].Complete || 
                Columns[2].Complete ||
                Diagonals[0].Complete || 
                Diagonals[1].Complete;
        }
    }
}