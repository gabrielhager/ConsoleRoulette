//Created in collaboration with Matthew Forbes
using System;

namespace ConsoleRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            string playAgain = "";
            do
            {
                PlayGame();
                Console.WriteLine("Play Again?\nY/N");
                playAgain = Console.ReadLine();
                playAgain = playAgain.ToLower();
            } while (playAgain == "y");
        }
        public static int Roll(Random rand) => rand.Next(0, 38);
        public static void PlayGame()
        {
            try
            {
                Random rand = new Random();
                int[] rouletteWheelNumbers = GameBoard.createRouletteWheelNumbersArray();
                int[] rouletteColors = GameBoard.createColorArray();
                char[] boardColors = GameBoard.ColorBoard(rouletteColors);

                GameBoard.PrintBoard(rouletteWheelNumbers, boardColors);

                Console.WriteLine("WELCOME TO ROULETTE!!!!\nCHOOSE A BET:");
                Console.WriteLine("1. Number");
                Console.WriteLine("2. Even/Odd");
                Console.WriteLine("3. Red/Black");
                Console.WriteLine("4. High/Low");
                Console.WriteLine("5. Dozens");
                Console.WriteLine("6. Columns");
                Console.WriteLine("7. Streets");
                Console.WriteLine("8. Double Rows");
                Console.WriteLine("9. Splits");
                Console.WriteLine("10. Corners");

                int input = Int32.Parse(Console.ReadLine());
                int rollResult = Roll(rand);

                switch (input)
                {
                    case 1:
                        Bets.BetNumber(rollResult);
                        break;
                    case 2:
                        Bets.BetEvenOdd(rollResult);
                        break;
                    case 3:
                        Bets.BetRedBlack(rollResult, rouletteWheelNumbers, rouletteColors);
                        break;
                    case 4:
                        Bets.BetHighLow(rollResult);
                        break;
                    case 5:
                        Bets.BetDozens(rollResult);
                        break;
                    case 6:
                        Bets.BetColumn(rollResult, rouletteWheelNumbers);
                        break;
                    case 7:
                        Bets.BetStreet(rollResult, rouletteWheelNumbers);
                        break;
                    case 8:
                        Bets.BetDoubleRows(rollResult, rouletteWheelNumbers);
                        break;
                    case 9:
                        Bets.BetSplits(rollResult, rouletteWheelNumbers);
                        break;
                    case 10:
                        Bets.BetCorner(rollResult, rouletteWheelNumbers);
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
    

