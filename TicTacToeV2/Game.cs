namespace TicTacToe
{
    class Game
    {
        private Board Board { get; set; }

        private Player Player1 { get; set; }

        private Player Player2 { get; set; }

        public Game()
        {
            Board = new Board();
            Player1 = new Player(Symbol.Cross);
            Player2 = new Player(Symbol.Circle);
        }

        public void Play()
        {
            Board.Draw();
            Player player = Player1;
            while (true)
            {
                player.PlaceSymbol(Board);
                Board.Draw();
                if (Board.HasCompleteLine())
                {
                    System.Console.WriteLine("Winner is: " + player.Symbol);
                    break;
                }
                else if (Board.Full())
                {
                    System.Console.WriteLine("Draw.");
                    break;
                }
                player = player == Player1 ? Player2 : Player1;
            }
        }
    }
}