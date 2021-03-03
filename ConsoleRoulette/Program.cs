using System;

namespace ConsoleRoulette
{
    class Program
    {
        public enum BoardColors
        {
            Green, Red, Black
        }
        static void Main(string[] args)
        {
            PlayGame();
            PlayGame();
            PlayGame();
            PlayGame();
            PlayGame();
            PlayGame();
            //var colorName = (BoardColors)0;

            //for (int i = 0; i < rouletteColors.Length; i++)
            //{
            //    colorName = (BoardColors)rouletteColors[i];
            //    Console.WriteLine(rouletteWheelNumbers[i] + " " + colorName.ToString());
            //}
        }

        public static int[] createRouletteWheelNumbersArray()
        {
            int[] rouletteWheelNumArray = new int[38];

            for (int i = 0; i < rouletteWheelNumArray.Length - 1; i++)
            {
                rouletteWheelNumArray[i] = i;
            }
            rouletteWheelNumArray[rouletteWheelNumArray.Length - 1] = 00;
            return rouletteWheelNumArray;
        }

        public static int[] createColorArray()
        {
            int[] boardColors = { 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 
                1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 1, 2, 1, 0 };

            return boardColors;
        }

        public static int Roll(Random rand) => rand.Next(0, 38);

        public static void PlayGame()
        {
            Random rand = new Random();
            int[] rouletteWheelNumbers = createRouletteWheelNumbersArray();
            int[] rouletteColors = createColorArray();

            Console.WriteLine("WELCOME TO ROULETTE!!!!\nCHOOSE A BET:");
            Console.WriteLine("2. Even/Odd");
            Console.WriteLine("3. Red/Black");
            Console.WriteLine("4. High/Low");
            Console.WriteLine("5. Dozens");

            int input = Int32.Parse(Console.ReadLine());
            int rollResult = Roll(rand);

            switch (input)
            {
                case 2:
                    BetEvenOdd(rollResult);
                    break;
                case 3:
                    BetRedBlack(rollResult, rouletteWheelNumbers, rouletteColors);
                    break;
                case 4:
                    BetHighLow(rollResult);
                    break;
                case 5:
                    BetDozens(rollResult);
                    break;
            }
        }
        public static void BetEvenOdd(int resultOfRoll)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked Even/Odd!\nPlease pick Even or Odd\n1. Even\n2. Odd");
            int input = Int32.Parse(Console.ReadLine());

            if(resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, you lose this round!");
                return;
            }

            switch (input)
            {
                case 1:
                    if(resultOfRoll % 2 == 0)
                        Console.WriteLine($"{resultOfRoll} is even, you win!");
                    else Console.WriteLine($"{resultOfRoll} is odd, you lose!");
                    break;
                case 2:
                    if (resultOfRoll % 2 != 0)
                        Console.WriteLine($"{resultOfRoll} is odd, you win!");
                    else Console.WriteLine($"{resultOfRoll} is even, you lose!");
                    break;
            }
        }

        public static void BetRedBlack(int resultOfRoll, int[] numbers, int[] colors)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked Red/Black!\nPlease pick Red or Black\n1. Red\n2. Black");
            int input = Int32.Parse(Console.ReadLine());

            if (resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, this is green. You lose this round!");
                return;
            }

            int indexPos = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (resultOfRoll == numbers[i])
                    indexPos = i;
            }

            switch (input)
            {
                case 1:
                    if ( colors[indexPos] == 1)
                        Console.WriteLine($"{resultOfRoll} is Red, you win!");
                    else Console.WriteLine($"{resultOfRoll} is Black, you lose!");
                    break;
                case 2:
                    if (colors[indexPos] == 2)
                        Console.WriteLine($"{resultOfRoll} is Black, you win!");
                    else Console.WriteLine($"{resultOfRoll} is Red, you lose!");
                    break;
            }
        }

        public static void BetHighLow(int resultOfRoll)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked High/Low!\nPlease pick High or Low\n1. High\n2. Low");
            int input = Int32.Parse(Console.ReadLine());

            if (resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, these do not fall under high/low. You lose this round!");
                return;
            }

            switch (input)
            {
                case 1:
                    if (resultOfRoll > 18)
                        Console.WriteLine($"{resultOfRoll} is high, you win!");
                    else Console.WriteLine($"{resultOfRoll} is low, you lose!");
                    break;
                case 2:
                    if (resultOfRoll <= 18)
                        Console.WriteLine($"{resultOfRoll} is low, you win!");
                    else Console.WriteLine($"{resultOfRoll} is high, you lose!");
                    break;
            }
        }

        public static void BetDozens(int resultOfRoll)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked Dozens!\nPlease pick 1-12, 13-24, 25-36\n1. 1-12\n2. 13-24\n3.25-36");
            int input = Int32.Parse(Console.ReadLine());

            if (resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, these do not fall under dozens You lose this round!");
                return;
            }

            switch (input)
            {
                case 1:
                    if (resultOfRoll < 13)
                        Console.WriteLine($"{resultOfRoll} is within 1-12, you win!");
                    else if (resultOfRoll < 25) Console.WriteLine($"{resultOfRoll} is within 13-24, you lose!");
                    else Console.WriteLine($"{resultOfRoll} is within 25-36, you lose!");
                    break;
                case 2:
                    if (resultOfRoll < 13)
                        Console.WriteLine($"{resultOfRoll} is within 1-12, you lose!");
                    else if (resultOfRoll < 25) Console.WriteLine($"{resultOfRoll} is within 13-24, you win!");
                    else Console.WriteLine($"{resultOfRoll} is within 25-36, you lose!");
                    break;
                case 3:
                    if (resultOfRoll < 13)
                        Console.WriteLine($"{resultOfRoll} is within 1-12, you lose!");
                    else if (resultOfRoll < 25) Console.WriteLine($"{resultOfRoll} is within 13-24, you lose!");
                    else Console.WriteLine($"{resultOfRoll} is within 25-36, you win!");
                    break;
            }
        }
    }
}
