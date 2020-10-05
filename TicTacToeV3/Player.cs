namespace TicTacToe
{
    class Player
    {
        public Symbol Symbol { get; private set; }

        public Player(Symbol symbol)
        {
            Symbol = symbol;
        }

        public void PlaceSymbol(Board board)
        {
            System.Console.WriteLine($"Player {Symbol} -  place your marker.");
            while (true)
            {
                int row = GetIndex("Row: ");
                int col = GetIndex("Column: ");

                if (board[row, col] == Symbol.Blank)
                {
                    board[row, col] = Symbol;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Occupied position. Try again.");
                }
            }
        }

        static private int GetIndex(string prompt)
        {
            while (true)
            {
                System.Console.Write(prompt);
                char symbol = System.Console.ReadKey().KeyChar;
                System.Console.WriteLine();
                if (symbol == '1' || symbol == '2' || symbol == '3')
                {
                    return int.Parse(symbol.ToString()) - 1;
                }
                System.Console.WriteLine("Valid inputs are 1, 2 or 3. Try again.");
            }
        }
    }
}