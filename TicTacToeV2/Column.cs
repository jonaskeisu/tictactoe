namespace TicTacToe
{
    class Column
    {
        private int Index { get; set; }

        private Board Board { get; set; }

        public Symbol this[int i]
        {
            get => Board[i, Index];
            set => Board[i, Index] = value;
        }

        public bool Complete =>
            this[0] != Symbol.Blank &&  
                this[0] == this[1] && this[1] == this[2];
                
        public Column(Board board, int index)
        {
            Board = board;
            Index = index;
        }

    }
}