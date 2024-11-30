using DiceLaunch;
namespace Dice
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Inserire il numero di lanci che vuoi fare");
            int LaunchNum;
            bool SuccesLaunch;
            do
            {
                SuccesLaunch = int.TryParse(Console.ReadLine(), out LaunchNum);
            } while (!SuccesLaunch);

            Game Game1 = new Game(LaunchNum);
            Result Result = Game1.DoTurn();

            if (Result != Result.PLAYER1INVALID && Result != Result.PLAYER2INVALID)
            {
                Console.WriteLine("Inserire il numero per vedere la frequenza di un certo numero");
                int Num;
                bool SuccesNum;
                do
                {
                    SuccesNum = int.TryParse(Console.ReadLine(), out Num);
                } while (!SuccesNum);

                Console.WriteLine($"la frequenza totale di tutti e due i giocatori insieme è del {Game1.FrequencyTurnNum(Num)}%");
                Console.WriteLine($"la frequenza del primo giocatore è del {Game1.Player1.FrequencyPlayerNum(Num)}%");
                Console.WriteLine($"la frequenza del secondo giocatore è del {Game1.Player2.FrequencyPlayerNum(Num)}%");
            }
            else
            {
                Console.WriteLine("Il gioco è truccato");
            }
            Console.WriteLine("Ancora?");
        }
    }
}
