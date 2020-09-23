using System;

namespace tictactoe
{
    struct Board
    {
        Square[,] squares;

        public Board(Symbol initSymbol)
        {
            squares = new Square[3, 3];
            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {
                    squares[row, col].symbol = initSymbol;
                }
            }
        }

        public bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3;
        }

        public bool IsBlank(int row, int col)
        {
            return squares[row, col].symbol == Symbol.Blank;
        }

        public void Place(Symbol symbol, int row, int col)
        {
            squares[row, col].symbol = symbol;
        }

        public bool IsFull
        {
            get
            {
                for (int row = 0; row < 3; ++row)
                {
                    for (int col = 0; col < 3; ++col)
                    {
                        if (squares[row, col].symbol == Symbol.Blank)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool HasFullRow
        {
            get
            {
                for (int row = 0; row < 3; ++row)
                {
                    if (IsFullLine(row, 0, 0, 1))
                    {
                        return true;
                    }
                }

                for (int col = 0; col < 3; ++col)
                {
                    if (IsFullLine(0, col, 1, 0))
                    {
                        return true;
                    }
                }

                if (IsFullLine(0, 0, 1, 1))
                {
                    return true;
                }

                if (IsFullLine(0, 2, 1, -1))
                {
                    return true;
                }

                return false;
            }
        }

        private bool IsFullLine(int startRow, int startCol, int stepRow, int stepCol)
        {
            return squares[startRow, startCol].symbol != Symbol.Blank &&
                (squares[startRow, startCol].symbol ==
                squares[startRow + stepRow, startCol + stepCol].symbol) &&
                (squares[startRow, startCol].symbol ==
                squares[startRow + stepRow * 2, startCol + stepCol * 2].symbol);
        }

        public void Draw() {
            Console.WriteLine("  1 2 3");
            Console.WriteLine(" =======");
            for (int row = 0; row < 3; ++row) {
                Console.Write($"{row + 1}|");
                for (int col = 0; col < 3; ++col) {
                    Console.Write(squares[row, col].symbol switch {
                        Symbol.Circle => "O",
                        Symbol.Cross => "X",
                        _ => " ",
                    } + "|");
                }
                Console.WriteLine();
                Console.WriteLine(" -------");
            }
        }
    }
}