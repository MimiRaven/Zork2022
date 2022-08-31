using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("> ");
                string inputString = Console.ReadLine().Trim();
                Commands command = ToCommand(inputString);

                string outputString;

                switch (command)
                {
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                    case Commands.NORTH:
                        outputString = $"You moved {command}.";
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
