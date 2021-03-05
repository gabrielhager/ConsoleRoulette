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
            string playAgain = "";
            do
            {
                PlayGame();
                Console.WriteLine("Play Again?\nY/N");
                playAgain = Console.ReadLine();
                playAgain = playAgain.ToLower();
            } while (playAgain == "y");
            
           
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
            try
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
                Console.WriteLine("10. Corners");

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
                    case 10:
                        BetCorner(rollResult, rouletteWheelNumbers);
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
        public static void PrintBoard(int[] numbers)
        {
            char row = 'a';
            Console.WriteLine("\t_______ 0 ______ 00_______");
            Console.WriteLine("\t__________________________");
            Console.WriteLine("\t_______ 1 ______ 2 _______");
            Console.Write("\t");
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                
                if(i<10)
                {
                    Console.Write($"____{numbers[i]}___ ");
                }
                else Console.Write($"___{numbers[i]}___ ");

                if (i % 3 == 0 && i <numbers.Length - 2)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{row++}\t________*________*________");
                    Console.Write("\t");
                }
            }
            Console.WriteLine("\n\t__________________________");
        }
        public static void YouWin(string bet, int winNum) => Console.WriteLine($"You bet on the {bet} corner! The ball landed on {winNum}, you win!");
        public static void YouLose(string bet, int winNum) => Console.WriteLine($"You bet on the {bet} corner! The ball landed in {winNum}, so you lose comrade!");
        public static void BetCorner(int roll, int[] wheelNumbers)
        {
            Console.WriteLine("Here is the board you will need for the Corner Bet");
            PrintBoard(wheelNumbers);

            string corner = "";
            do
            {
                Console.WriteLine("Please select one of the corners listed above (e.g. A1, A2, G1, etc.): ");
                corner = Console.ReadLine();

                corner = corner.ToUpper();

                switch (corner)
                {
                    case "A1":
                        if (roll == 1 || roll == 2 || roll == 4 || roll == 5)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "A2":
                        if (roll == 2 || roll == 3 || roll == 5 || roll == 6)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "B1":
                        if (roll == 4 || roll == 5 || roll == 7 || roll == 8)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "B2":
                        if (roll == 5 || roll == 6 || roll == 8 || roll == 9)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "C1":
                        if (roll == 7 || roll == 8 || roll == 10 || roll == 11)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "C2":
                        if (roll == 8 || roll == 9 || roll == 11 || roll == 12)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "D1":
                        if (roll == 10 || roll == 11 || roll == 13 || roll == 14)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "D2":
                        if (roll == 11 || roll == 12 || roll == 14 || roll == 15)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "E1":
                        if (roll == 13 || roll == 14 || roll == 16 || roll == 17)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "E2":
                        if (roll == 14 || roll == 15 || roll == 17 || roll == 18)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "F1":
                        if (roll == 16 || roll == 17 || roll == 19 || roll == 20)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "F2":
                        if (roll == 17 || roll == 18 || roll == 20 || roll == 21)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "G1":
                        if (roll == 19 || roll == 20 || roll == 22 || roll == 23)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "G2":
                        if (roll == 20 || roll == 21 || roll == 23 || roll == 24)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "H1":
                        if (roll == 22 || roll == 23 || roll == 25 || roll == 26)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "H2":
                        if (roll == 23 || roll == 24 || roll == 26 || roll == 27)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "I1":
                        if (roll == 25 || roll == 26 || roll == 28 || roll == 29)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "I2":
                        if (roll == 26 || roll == 27 || roll == 29 || roll == 30)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "J1":
                        if (roll == 28 || roll == 29 || roll == 31 || roll == 32)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "J2":
                        if (roll == 29 || roll == 30 || roll == 32 || roll == 33)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "K1":
                        if (roll == 31 || roll == 32 || roll == 34 || roll == 35)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    case "K2":
                        if (roll == 32 || roll == 33 || roll == 35 || roll == 36)
                        {
                            YouWin(corner, roll);
                        }
                        else YouLose(corner, roll);
                        break;
                    default:
                        Console.WriteLine("You have not entered a valid selection, please try again.");
                        corner = "Not valid";
                        break;
                }
            }
            while (corner == "Not valid");
        }


    }
}
    

