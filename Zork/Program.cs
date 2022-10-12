using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

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

        private static Room[,] rooms;

        static void Main(string[] args)
        {
            const string defaultRoomsFilename = "Rooms.json";
            string roomsFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);
            InitializeRooms(roomsFilename);
            Console.WriteLine("Welcome to Zork!");

            Room previousRoom = null;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(CurrentRoom);
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }

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

        private static readonly Dictionary<string, Room> RoomMap;

        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }

        private static void InitializeRooms(string roomsFilename) =>
            rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));

        private static int currentRow = 1;
        private static int currentColumn = 1;
    }
}
