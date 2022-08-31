using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            //Console.WriteLine(command);

            if (command == Commands.QUIT)
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (command == Commands.LOOK)
            {
                Console.WriteLine("This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.");
            }
            else if (command == Commands.NORTH)
            {
                Console.WriteLine("You moved north.");
            }
            else if (command == Commands.SOUTH)
            {
                Console.WriteLine("You moved south.");
            }
            else if (command == Commands.EAST)
            {
                Console.WriteLine("You moved east.");
            }
            else if (command == Commands.WEST)
            {
                Console.WriteLine("You moved west.");
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
            }
        }

        private static Commands ToCommand(string commandString)
        {
          //Commands command;

        //   if (Enum.TryParse<Commands>(commandString, true, out Commands result))
        //   {
        //       return result;
        //   }
        //   else
        //   {
        //       return Commands.UNKNOWN;
        //   }

            try
            {
                return (Commands)Enum.Parse(typeof(Commands), commandString, true);
            }
            catch (ArgumentException)
            {
                return Commands.UNKNOWN;
            }

          //return Enum.Parse<Commands>(commandString, true);

       //   switch (commandString)
       //   {
       //       case "QUIT":
       //           command = Commands.QUIT;
       //           break;
       //       case "NORTH":
       //           command = Commands.NORTH;
       //           break;
       //       case "SOUTH":
       //           command = Commands.SOUTH;
       //           break;
       //       case "EAST":
       //           command = Commands.EAST;
       //           break;
       //       case "WEST":
       //           command = Commands.WEST;
       //           break;
       //       default:
       //           command = Commands.UNKNOWN;
       //           break;
       //   }

          //return command;

        // if (commandString == "QUIT")
        // {
        //     command = Commands.QUIT;
        // }
        // else if (commandString == "LOOK")
        // {
        //     command = Commands.LOOK;
        // }
        // else if (commandString == "NORTH")
        // {
        //     command = Commands.NORTH;
        // }
        // else if (commandString == "SOUTH")
        // {
        //     command = Commands.SOUTH;
        // }
        // else if (commandString == "EAST")
        // {
        //     command = Commands.EAST;
        // }
        // else if (commandString == "WEST")
        // {
        //     command = Commands.WEST;
        // }
        // else
        // {
        //     command = Commands.UNKNOWN;
        // }
        }
    }
}
