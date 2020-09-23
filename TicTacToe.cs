using System;

namespace tictactoe
{
    class Program
    {
        static int UserInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                char symbol = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (symbol == '1' || symbol == '2' || symbol == '3')
                {
                    return int.Parse(symbol.ToString());
                }
                Console.WriteLine("Du måste trycka: 1, 2 eller 3. Försök igen.");
            }
        }

        static void Main(string[] args)
        {
            string PlayerName(Symbol activePlayer) =>
                activePlayer switch
                {
                    Symbol.Circle => "Ring",
                    _ => "Kryss",
                };

            Board board = new Board(Symbol.Blank);

            Symbol activePlayer = Symbol.Circle;

            while (true)
            {
                board.Draw();
                Console.WriteLine();

                Console.WriteLine($"{PlayerName(activePlayer)} spelar.");
                Console.WriteLine();

                while (true)
                {
                    int row = UserInput("Rad: ") - 1;
                    int col = UserInput("Kolumn: ") - 1;

                    if (board.IsValidPosition(row, col) &&
                        board.IsBlank(row, col))
                    {
                        board.Place(activePlayer, row, col);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Positionen är upptagen. Försök igen.");
                    }
                }

                if (board.HasFullRow)
                {
                    board.Draw();
                    Console.WriteLine($"{PlayerName(activePlayer)} vann!");
                    break;
                }

                if (board.IsFull)
                {
                    Console.WriteLine("Det blev oavgjort.");
                    break;
                }

                activePlayer = activePlayer == Symbol.Circle ? Symbol.Cross : Symbol.Circle;
            }
        }
    }
}
