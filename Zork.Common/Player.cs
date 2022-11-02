using System;
using System.Collections.Generic;

namespace Zork.Common
{
    public class Player
    {
        public Room CurrentRoom
        {
            get => _currentRoom;
            set => _currentRoom = value;
        }

        public List<Item> Inventory { get; }


        public Player(World world, string startingLocation)
        {
            _world = world;

            if (_world.RoomsByName.TryGetValue(startingLocation, out _currentRoom) == false)
            {
                throw new Exception($"Invalid starting location: {startingLocation}");
            }

            Inventory = new List<Item>();
        }

        public bool Move(Directions direction)
        {
            bool didMove = _currentRoom.Neighbors.TryGetValue(direction, out Room neighbor);
            if (didMove)
            {
                CurrentRoom = neighbor;
            }

            return didMove;
        }

        public bool Take(string itemName)
        {
            Item itemToTake = _world.ItemsByName.GetValueOrDefault(itemName);

            if(CurrentRoom.Inventory.Contains(itemToTake))
            {
                Inventory.Add(itemToTake);
                CurrentRoom.Inventory.Remove(itemToTake);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Drop(string itemName)
        {
            Item itemToTake = _world.ItemsByName.GetValueOrDefault(itemName);

                if (Inventory.Contains(itemToTake))
            {
                Inventory.Remove(itemToTake);
                CurrentRoom.Inventory.Add(itemToTake);
                return true;
            }
            else
            {
                return false;
            }
        }

        private World _world;
        private Room _currentRoom;
    }
}
