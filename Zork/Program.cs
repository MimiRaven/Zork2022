using System;
using System.Security.Cryptography.X509Certificates;

namespace Zork
{
    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return rooms[currentRow, currentColumn];
            }
        }

        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch (command)
            {
                case Commands.NORTH when currentRow < rooms.GetLength(0) - 1:
                    currentRow++;
                    didMove = true;
                    break;

                case Commands.SOUTH when currentRow > 0:
                    currentRow--;
                    didMove = true;
                    break;

                case Commands.EAST when currentColumn < rooms.GetLength(1) - 1:

                    currentColumn++;
                    didMove = true;
                    break;

                case Commands.WEST when currentColumn > 0:

                    currentColumn--;
                    didMove = true;
                    break;
            }




            return didMove;
        }

        private static readonly string[,] rooms =
        {
            { "Rocky Trail", "South of House", "Canyon View" },
            { "Forest", "West of House", "Behind House" },
            { "Dense Woods", "North of House", "Clearing" }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            bool isRunning = true;

            while (isRunning)
            {
                Console.Write($"{CurrentRoom}\n> ");
                string inputString = Console.ReadLine().Trim();
                Commands command = ToCommand(inputString);

                string outputString;

                switch (command)
                {
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                    case Commands.NORTH:
                        if (Move(command))
                        {
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }

                        break;

                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.QUIT:
                        isRunning = false;
                        outputString = "Thank you for playing!";
                        break;

                    default:
                        outputString = $"Unknown command: {inputString}";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString)
        {
            try
            {
                return (Commands)Enum.Parse(typeof(Commands), commandString, true);
            }
            catch (ArgumentException)
            {
                return Commands.UNKNOWN;
            }
        }

        private static int currentRow = 1;
        private static int currentColumn = 1;
    }
}
