namespace TicTacToe
{
    class Row
    {
        private int Index { get; set; }
        private Board Board { get; set; }

        public Symbol this[int i]
        {
            get => Board[Index, i];
            set => Board[Index, i] = value;
        }

        public bool Complete =>
            this[0] != Symbol.Blank &&  
                this[0] == this[1] && this[1] == this[2];

        public Row(Board board, int index)
        {
            Board = board;
            Index = index;
        }
    }
}