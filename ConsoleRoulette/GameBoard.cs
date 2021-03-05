using System;


namespace ConsoleRoulette
{
    class GameBoard
    {
        public static void PrintBoard(int[] numbers, char[] colors)
        {
            Console.Write("\t__________________________");
            Console.WriteLine("\t__________________________");
            Console.Write("\t_______ 0 ______ 00 ______");
            Console.WriteLine("\t_______ G ______ G _______");
            Console.Write("\t");
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (i < 10)
                {
                    Console.Write($"____{numbers[i]}___ ");
                }
                else Console.Write($"___{numbers[i]}___ ");

                if (i % 3 == 0 && i < numbers.Length - 1)
                {
                    Console.Write("\t");
                    for (int j = i - 2; j <= i; j++)
                        Console.Write($"____{colors[j]}___ ");
                    Console.WriteLine();
                    Console.Write($"\t__________________________");
                    Console.WriteLine($"\t__________________________");
                    Console.Write("\t");
                }
            }
            Console.WriteLine("");
        }
        public static void PrintBoardCorners(int[] numbers)
        {
            char row = 'a';
            Console.WriteLine("\t_______ 0 ______ 00_______");
            Console.WriteLine("\t__________________________");
            Console.WriteLine("\t_______ 1 ______ 2 _______");
            Console.Write("\t");
            for (int i = 1; i < numbers.Length - 1; i++)
            {

                if (i < 10)
                {
                    Console.Write($"____{numbers[i]}___ ");
                }
                else Console.Write($"___{numbers[i]}___ ");

                if (i % 3 == 0 && i < numbers.Length - 2)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{row++}\t________*________*________");
                    Console.Write("\t");
                }
            }
            Console.WriteLine("\n\t__________________________");
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
        public static char[] ColorBoard(int[] colors)
        {

            char[] colorDisplayBoard = new char[colors.Length];

            for (int i = 0; i < colorDisplayBoard.Length; i++)
            {
                if (colors[i] == 0)
                {
                    colorDisplayBoard[i] = 'G';
                }
                else if (colors[i] == 1)
                {
                    colorDisplayBoard[i] = 'R';
                }
                else if (colors[i] == 2)
                {
                    colorDisplayBoard[i] = 'B';
                }
            }
            return colorDisplayBoard;
        }
    }
}
