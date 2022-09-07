using System;
using System.Security.Cryptography.X509Certificates;

namespace Zork
{
    class Program
    {
        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch(command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    break;

                case Commands.EAST when currentRoom < rooms.Length - 1:

                        currentRoom++;
                        didMove = true;
                        break;

                case Commands.WEST when currentRoom > 0:
                  
                        currentRoom--;
                        didMove = true;
                        break;
            }




            return didMove;
        }

        private static readonly string[] rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };

        private static int currentRoom = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            bool isRunning = true;

            while (isRunning)
            {
                Console.Write($"{rooms[currentRoom]}\n> ");
                string inputString = Console.ReadLine().Trim();
                Commands command = ToCommand(inputString);

                string outputString;

                switch (command)
                {
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                    case Commands.NORTH:
                        if(Move(command))
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
    }
}
