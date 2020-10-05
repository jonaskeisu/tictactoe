namespace TicTacToe
{
    class Diagonal : Line
    {
        private Direction Direction { get; set; }

        public Diagonal(Board board, Direction direction) : base(board)
        {
            Direction = direction;
        }

        override protected int IndexToBoardRow(int index) => index;
        
        override protected int IndexToBoardColumn(int index) => 
            Direction == Direction.DownRight ? index : 2 - index;

    }
}