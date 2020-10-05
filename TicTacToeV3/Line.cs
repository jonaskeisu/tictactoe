namespace TicTacToe
{
    abstract class Line
    {
        private Board Board { get; set; }

        public bool Complete => 
            this[0] != Symbol.Blank &&  this[0] == this[1] && this[1] == this[2];

        public Line(Board board)
        {
            Board = board;
        }

        abstract protected int IndexToBoardRow(int index);

        abstract protected int IndexToBoardColumn(int index);

        public Symbol this[int i]
        {
            get => Board[IndexToBoardRow(i), IndexToBoardColumn(i)];
            set => Board[IndexToBoardRow(i), IndexToBoardColumn(i)] = value;
        }
    }
}