namespace TicTacToe
{
    class Column : Line
    {
        private int Index { get; set; }

        public Column(Board board, int index) : base(board)
        {
            Index = index;
        }

        override protected int IndexToBoardRow(int index) => index;
        
        override protected int IndexToBoardColumn(int index) => Index;

    }
}