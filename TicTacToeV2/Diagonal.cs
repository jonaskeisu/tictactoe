namespace TicTacToe
{
    class Diagonal
    {
        private Direction Direction { get; set; }
        private Board Board { get; set; }

        public Symbol this[int i]
        {
            get => Board[i, Direction == Direction.DownRight ? i : 2 - i];
            set => Board[i, Direction == Direction.DownRight ? i : 2 - i] = value;
        }
        
        public bool Complete =>
            this[0] != Symbol.Blank &&  
                this[0] == this[1] && this[1] == this[2];

        public Diagonal(Board board, Direction direction)
        {
            Board = board;
            Direction = direction;
        }

    }
}