using System.Security.Cryptography.X509Certificates;

namespace DiceLaunch
{
    public enum Result
    {
        Player1Win,
        Player2Win,
        Player1Invalid,
        Player2Invalid,
        Draw
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
            if (!Player1.isValid()) return Result.Player1Invalid;
            Player2.launch();
            if (!Player2.isValid()) return Result.Player2Invalid;
            if (Player1.TotPoints>Player2.TotPoints)
            {
                return Result.Player1Win;
            }
            else if (Player2.TotPoints>Player1.TotPoints)
            {
                return Result.Player2Win;
            }
            else
            {
                return Result.Draw;
            }

        }

        public int FrequencyTurnNum(int num)
        {
            if (num < 1 || num > 6) throw new ArgumentOutOfRangeException("Num need to be a valid number");
            return (Player1.Counters[num - 1] + Player2.Counters[num-1]) / (Player1.Points.Length * 2) * 100;
        }
    }
}
