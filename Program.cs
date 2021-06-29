using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static int threeInARowVert = 0;
        private static int threeInARowVert1 = 0;
        private static int threeInARowVert2 = 0;
        private static int threeInARowHorizon = 0;
        private static int threeInARowHorizon1 = 0;
        private static int threeInARowHorizon2 = 0;
        private static int leftDiagonalMatch = 0;
        private static int rightDiagonalMatch = 0;

        private static int isInt;
        private static string marker = "X";
        private static string selection;
        private static bool hasWon = false;
        private static bool player1 = false;
        private static List<int> selectedNums = new List<int>();

        private static string[,] ticTacToeArr = new string[3, 3] 
        {
            { "1", "2", "3" }, // 00 01 02
            { "4", "5", "6" }, // 10 11 12
            { "7", "8", "9" }  // 20 21 22
        };

        static void Main(string[] args)
        {
            SetupGame();

            while (hasWon == false)
            {
                SetMarker();
                AskQuestion();
                MakeSelection();

                Console.Clear();
                SetupGame();
            }

            DisplayWinner();

            Console.Read();
        }

        private static void SetupGame() 
        {
            Console.WriteLine("|-----------|");

            threeInARowVert = 0;
            threeInARowVert1 = 0;
            threeInARowVert2 = 0;
            rightDiagonalMatch = 0;

            // Row
            for (int i = 0, k = 2; i < ticTacToeArr.GetLength(0); i++, k--)
            {
                Console.Write("| ");

                threeInARowHorizon = 0;
                threeInARowHorizon1 = 0;
                threeInARowHorizon2 = 0;
                leftDiagonalMatch = 0;

                // Column
                for (int j = 0; j < ticTacToeArr.GetLength(1); j++)
                {
                    if (ticTacToeArr[0, j] == marker) threeInARowHorizon++;
                    if (ticTacToeArr[1, j] == marker) threeInARowHorizon1++;
                    if (ticTacToeArr[2, j] == marker) threeInARowHorizon2++;

                    if (j == 0 && ticTacToeArr[i, j] == marker) threeInARowVert++;
                    if (j == 1 && ticTacToeArr[i, j] == marker) threeInARowVert1++;
                    if (j == 2 && ticTacToeArr[i, j] == marker) threeInARowVert2++;

                    Console.Write(ticTacToeArr[i, j] + " | ");
                }

                if (ticTacToeArr[i, k] == marker) rightDiagonalMatch++;

                Console.WriteLine("");
                Console.WriteLine("|-----------|");
            }

            if (HasMatch()) hasWon = true;

            Console.WriteLine("");
        }

        private static void DisplayWinner() 
        {
            if (player1)
            {
                Console.WriteLine("Player 1 WINS!");
            }
            else
            {
                Console.WriteLine("Player 2 WINS!");
            }

        }

        private static bool HasMatch() {
            return threeInARowHorizon == 3
                || threeInARowHorizon1 == 3
                || threeInARowHorizon2 == 3
                || threeInARowVert == 3
                || threeInARowVert1 == 3
                || threeInARowVert2 == 3
                || leftDiagonalMatch == 3
                || rightDiagonalMatch == 3;
        }

        private static void SetMarker() 
        {
            player1 = !player1;

            if (player1)
            {
                Console.WriteLine("Player 1");
            }
            else
            {
                Console.WriteLine("Player 2");
            }

            marker = player1 ? "X" : "O";
        }

        private static void AskQuestion()
        {
            do
            {
                Console.WriteLine("Select your number: ");
                selection = Console.ReadLine();


                int.TryParse(selection, out isInt);

                if (isInt == 0)
                {
                    Console.WriteLine("Incorrect input.");
                    Console.WriteLine("");
                }
                else
                {
                    int parsedInt = int.Parse(selection);
                    if (parsedInt > ticTacToeArr.Length || selectedNums.Contains(parsedInt))
                    {
                        isInt = 0;
                        Console.WriteLine("");
                        Console.WriteLine("Please choose a number between 1 and 9 that has not already been selected.");
                        Console.WriteLine("");
                    }
                    else {
                        selectedNums.Add(parsedInt);
                    }
                }
            }
            while (isInt == 0);
        }

        private static void MakeSelection() 
        {
            switch (selection)
            {
                case "1":
                    ticTacToeArr[0, 0] = marker;
                    break;
                case "2":
                    ticTacToeArr[0, 1] = marker;
                    break;
                case "3":
                    ticTacToeArr[0, 2] = marker;
                    break;
                case "4":
                    ticTacToeArr[1, 0] = marker;
                    break;
                case "5":
                    ticTacToeArr[1, 1] = marker;
                    break;
                case "6":
                    ticTacToeArr[1, 2] = marker;
                    break;
                case "7":
                    ticTacToeArr[2, 0] = marker;
                    break;
                case "8":
                    ticTacToeArr[2, 1] = marker;
                    break;
                case "9":
                    ticTacToeArr[2, 2] = marker;
                    break;

            };
        }

    }
}
