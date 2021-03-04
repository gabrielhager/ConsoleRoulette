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
            Console.WriteLine("1. Number");
            Console.WriteLine("2. Even/Odd");
            Console.WriteLine("3. Red/Black");
            Console.WriteLine("4. High/Low");
            Console.WriteLine("5. Dozens");
            Console.WriteLine("6. Columns");
            Console.WriteLine("7. Streets");
            Console.WriteLine("8. Double Rows");
            Console.WriteLine("9. Splits");

            int input = Int32.Parse(Console.ReadLine());
            int rollResult = Roll(rand);

            switch (input)
            {
                case 1:
                    BetNumber(rollResult);
                    break;
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
                case 6:
                    BetColumn(rollResult, rouletteWheelNumbers);
                    break;
                case 7:
                    BetStreet(rollResult, rouletteWheelNumbers);
                    break;
                case 8:
                    BetDoubleRows(rollResult, rouletteWheelNumbers);
                    break;
                case 9:
                    BetSplits(rollResult, rouletteWheelNumbers);
                    break;
            }
        }
        public static void BetNumber(int resultOfRoll)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked individual Number!\nPlease enter a number on the board (00,0-36)");
            string inputString = Console.ReadLine();
            if (inputString == "00") inputString = "37";
            int input = Int32.Parse(inputString);

            if (input == 37 && resultOfRoll == 37)
            {
                Console.WriteLine($"You picked 00, the ball is in bin #00, you win!");
            }
            else if(input == 37 && resultOfRoll != 37)
            {
                Console.WriteLine($"You picked 00, the ball is in bin #{resultOfRoll}, you lose!");
            }
            else if (input != 37 && resultOfRoll == 37)
            {
                Console.WriteLine($"You picked {input}, the ball is in bin #00, you lose!");
            }
  
            else if(input == resultOfRoll)
            {
                Console.WriteLine($"You picked {input}, the ball is in bin #{resultOfRoll}, you win!");
            }
            else
                Console.WriteLine($"You picked {input}, the ball is in bin #{resultOfRoll}, you lose!");
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
        public static void BetColumn(int resultOfRoll, int[] numbers)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked Columns!\nPlease pick 1st, 2nd, or 3rd Column\n1. 1st\n2. 2nd\n3. 3rd");
            int input = Int32.Parse(Console.ReadLine());

            if (resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, this is not in any column. You lose this round!");
                return;
            }

            bool isInColumn = false;

            for (int i = input - 1; i < (numbers.Length - 2); i+=3)
            {
                if (resultOfRoll == numbers[i+1])
                    isInColumn = true;
                
            }

            switch (input)
            {
                case 1:
                    if (isInColumn)
                        Console.WriteLine($"{resultOfRoll} is in the 1st Column, you win!");
                    else Console.WriteLine($"{resultOfRoll} is not in the 1st Column, you lose!");
                    break;
                case 2:
                    if (isInColumn)
                        Console.WriteLine($"{resultOfRoll} is in the 2nd Column, you win!");
                    else Console.WriteLine($"{resultOfRoll} is not in the 2nd Column, you lose!");
                    break;
                case 3:
                    if (isInColumn)
                        Console.WriteLine($"{resultOfRoll} is in the 3rd Column, you win!");
                    else Console.WriteLine($"{resultOfRoll} is not in the 3rd Column, you lose!");
                    break;
            }
        }
        public static void BetStreet(int resultOfRoll, int[] numbers)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("You picked Streets!\nPlease pick a row (1-12)");
            int input = Int32.Parse(Console.ReadLine());

            if (resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, this is not in any Street. You lose this round!");
                return;
            }

            int streetCounter = 1;
            int streetBallIsIn = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (resultOfRoll == numbers[i])
                    streetBallIsIn = streetCounter;
                if( i % 3 == 0 )
                {
                    streetCounter++;
                }
            }
            if(input == streetBallIsIn)
                Console.WriteLine($"You bet on street #{input}, the ball is in street number {streetBallIsIn}, you win!");
            else Console.WriteLine($"You bet on street #{input}, the ball is in street number {streetBallIsIn}, you lose!");
        }
        public static void BetDoubleRows(int resultOfRoll, int[] numbers)
        {
            Console.WriteLine("***************************************");
            Console.Write("You picked Double Rows!\nPlease pick a the first row between (1-11)\nRow 1:");
            int input = Int32.Parse(Console.ReadLine());

            while(input >= 12 )
            {
                Console.Write("Your first row cannnot be the last row! (12)\nPlease pick again.\nRow 1: ");
                input = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine($"You picked row {input} your second row is {input + 1}");
         

            if (resultOfRoll == 0 || resultOfRoll == 37)
            {
                Console.WriteLine("You got 0 or 00, this is not in any Street. You lose this round!");
                return;
            }

            int rowCounter = 1;
            int rowBallIsIn = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (resultOfRoll == numbers[i])
                    rowBallIsIn = rowCounter;
                if (i % 3 == 0)
                {
                    rowCounter++;
                }
            }
            if (input == rowBallIsIn || input + 1 == rowBallIsIn)
                Console.WriteLine($"You bet on rows #{input} & {input + 1} the ball is in row number {rowBallIsIn}, you win!");
            else Console.WriteLine($"You bet on street #{input} & {input + 1} the ball is in row number {rowBallIsIn}, you lose!");
        }
        public static void BetSplits(int roll, int[] numbers)
        {

            int rowCounter = 1;
            int columnCounter = 1;
            int rowCounter2 = 1;
            int columnCounter2 = 1;
            int input1RowLanded = 0;
            int input1ColumnLanded = 0;
            int input2RowLanded = 0;
            int input2ColumnLanded = 0;

            Console.WriteLine("***************************************");

            Console.Write("You picked Split!\nPlease pick 2 adjacent numbers\nNum 1:");
            int input1 = Int32.Parse(Console.ReadLine());

            Console.Write("Num 2:");
            int input2 = Int32.Parse(Console.ReadLine());

            bool areValidInputs = false;
            //(!areValidInputs)
            do
            {
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (input1 == numbers[i])
                    {
                        input1RowLanded = rowCounter;
                        input1ColumnLanded = columnCounter;
                    }

                    if (i % 3 == 0)
                    {
                        rowCounter++;
                    }

                    if (columnCounter == 3)
                    {
                        columnCounter = 1;
                    }
                    else columnCounter++;
                    // NUMBER 2
                    if (input2 == numbers[i])
                    {
                        input2RowLanded = rowCounter2;
                        input2ColumnLanded = columnCounter2;
                    }

                    if (i % 3 == 0)
                    {
                        rowCounter2++;
                    }

                    if (columnCounter2 == 3)
                    {
                        columnCounter2 = 1;
                    }
                    else columnCounter2++;
                }

                if (input1RowLanded == input2RowLanded)
                {
                    if (input1ColumnLanded == input2ColumnLanded + 1 || input1ColumnLanded == input2ColumnLanded - 1)
                    {
                        areValidInputs = true;
                    }
                }

                if (input1ColumnLanded == input2ColumnLanded)
                {
                    if (input1RowLanded == input2RowLanded + 1 || input1RowLanded == input2RowLanded - 1)
                    {
                        areValidInputs = true;
                    }
                }

                if (!areValidInputs)
                {
                    rowCounter = 1;
                    columnCounter = 1;
                    rowCounter2 = 1;
                    columnCounter2 = 1;
                    Console.WriteLine("Invalid inputs. Inputs must be adjacent. Please re-enter appropriate values.");
                    Console.Write("Please pick 2 adjacent numbers\nNum 1:");
                    input1 = Int32.Parse(Console.ReadLine());

                    Console.Write("Num 2:");
                    input2 = Int32.Parse(Console.ReadLine());
                }
            }
            while (!areValidInputs);

            if (roll == input1 || roll == input2)
            {
                Console.WriteLine($"You picked {input1} and {input2}. Theroll landed on {roll}, so you win!");
            }
            else Console.WriteLine($"You picked {input1} and {input2}. Unfortunately, the roll landed on {roll}, so you lose!");



        }
    }
}
    

