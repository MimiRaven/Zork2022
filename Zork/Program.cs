using System;
using System.Security.Cryptography.X509Certificates;

namespace Zork
{
    class Program
    {
        private static Room CurrentRoom
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

        private static readonly Room[,] rooms =
        {
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }
        };

        static void Main(string[] args)
        {
            InitializeRoomDescription();
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
                        outputString = CurrentRoom.Description;
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

        private static void InitializeRoomDescription()
        {
            rooms[0, 0].Description = "You are on a rock-strewn trail.";
            rooms[0, 1].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred.";
            rooms[0, 2].Description = "You are at the top of the Great Canyon on its south wall.";

            rooms[1, 0].Description = "This is a forest, with trees in all directions around you.";
            rooms[1, 1].Description = "This is an open field west of a white house, with a boarded front door.";
            rooms[1, 2].Description = "You are behind the white house. In one corner of the house there is a small window which is slightly ajar.";

            rooms[2, 0].Description = "This is a dimly lit forest, with large trees all around. To the east, there appears to be sunlight.";
            rooms[2, 1].Description = "You are facing the north side of a white house. There is no door here, and all the windows are barred.";
            rooms[2, 2].Description = "You are in a clearing, with a forest surrounding you on the west and south.";
        }

        private static int currentRow = 1;
        private static int currentColumn = 1;
    }
}
