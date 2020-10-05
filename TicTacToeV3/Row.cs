namespace TicTacToe
{
    class Row : Line
    {
        private int Index { get; set; }

        public Row(Board board, int index) : base(board)
        {
            Index = index;
        }

        override protected int IndexToBoardRow(int index) => Index;
        
        override protected int IndexToBoardColumn(int index) => index;
    }
}