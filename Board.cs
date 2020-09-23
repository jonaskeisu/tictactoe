using System;

namespace tictactoe
{
    struct Board
    {
        Symbol[,] symbols;

        public Board(Symbol initSymbol)
        {
            symbols = new Symbol[3, 3];
            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {
                    symbols[row, col] = initSymbol;
                }
            }
        }

        public bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3;
        }

        public bool IsBlank(int row, int col)
        {
            return symbols[row, col] == Symbol.Blank;
        }

        public void Place(Symbol symbol, int row, int col)
        {
            symbols[row, col] = symbol;
        }

        public bool IsFull
        {
            get
            {
                for (int row = 0; row < 3; ++row)
                {
                    for (int col = 0; col < 3; ++col)
                    {
                        if (symbols[row, col] == Symbol.Blank)
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
            return symbols[startRow, startCol] != Symbol.Blank &&
                (symbols[startRow, startCol] ==
                symbols[startRow + stepRow, startCol + stepCol]) &&
                (symbols[startRow, startCol] ==
                symbols[startRow + stepRow * 2, startCol + stepCol * 2]);
        }

        public void Draw() {
            Console.WriteLine("  1 2 3");
            Console.WriteLine(" =======");
            for (int row = 0; row < 3; ++row) {
                Console.Write($"{row + 1}|");
                for (int col = 0; col < 3; ++col) {
                    Console.Write(symbols[row, col] switch {
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