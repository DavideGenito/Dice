namespace DiceLaunch
{
    public enum Result
    {
        PLAYER1WIN,
        PLAYER2WIN,
        PLAYER1INVALID,
        PLAYER2INVALID,
        DRAW
    }

    public class Game
    {
        public Player Player1;
        public Player Player2;
        public Game(int numLaunches)
        {
            if (numLaunches <= 0) throw new ArgumentOutOfRangeException("The number of launches need to be more than 0");
            Player1 = new Player(numLaunches);
            Player2 = new Player(numLaunches);
        }

        public Result DoTurn()
        {
            Player1.launch();
            if (!Player1.isValid()) return Result.PLAYER1INVALID;
            Player2.launch();
            if (!Player2.isValid()) return Result.PLAYER2INVALID;
            if (Player1.TotPoints > Player2.TotPoints)
            {
                return Result.PLAYER1WIN;
            }
            else if (Player2.TotPoints > Player1.TotPoints)
            {
                return Result.PLAYER2WIN;
            }
            else
            {
                return Result.DRAW;
            }

        }

        public double FrequencyTurnNum(int num)
        {
            if (num < 1 || num > 6) throw new ArgumentOutOfRangeException("Num need to be a valid number");
            return (double)(Player1.Counters[num - 1] + Player2.Counters[num - 1]) / (Player1.Points.Length * 2) * 100;
        }

        public int[] InWhatLaunch(int num)
        {
            if (num < 1 || num > 6) throw new ArgumentOutOfRangeException("Num need to be a valid number");
            int[] player1 = Player1.InWhatLaunch(num);
            int[] player2 = Player2.InWhatLaunch(num);
            int[] result = new int[player1.Length + player2.Length];
            for(int i=0; i< player1.Length; i++)
            {
                result[i] = player1[i];
            }
            for(int j=0; j< player2.Length; j++)
            {
                result[j+ player1.Length] = player2[j];
            }
            return result;
        }
    }
}
