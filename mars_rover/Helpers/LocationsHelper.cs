using System;
using System.Collections.Generic;
using System.Linq;

namespace mars_rover
{
    public class LocationsHelper
    {
        public string[] Letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
        Random random = new Random();

        public string GetRandomLocation()
        {
            int position = random.Next(1, 15);

            string randomLetter = Letters[position];

            string randomPosition = String.Concat(randomLetter, position);

            Dictionary<string, Object> MarsLocations = Locations();

            string randomLocation = MarsLocations.Where(location => location.Key.Equals(randomPosition)).First().Key;

            return randomLocation;

        }

        public string GetRandomOrientation()
        {
            List<string> availableOrientations = new List<string> { "NORTH", "SOUTH", "WEST", "EAST" };

            int index = random.Next(availableOrientations.Count);
            return availableOrientations[index];
        }

        public Dictionary<string, Object> Locations()
        {
            Dictionary<string, Object> MarsLocations = new Dictionary<string, Object> { };
            for (int i = 1; i < 16; i++)
            {
                for (int j = 0; j < Letters.Length; j++)
                {
                    string key = String.Concat(Letters[j], i);
                    int value = 0;

                    MarsLocations.Add(key, value);

                }
            }

            return MarsLocations;

        }

        public Dictionary<string, Object> LocationsWithRoverPosition(string roverPositon, string orientation)
        {
            Dictionary<string, Object> MarsLocations = Locations();
            string position = MarsLocations.Where(location => location.Key.Equals(roverPositon)).First().Key;

            Dictionary<string, string> Arrows = OrientationArrows();

            MarsLocations[position] = Arrows[orientation];

            return MarsLocations;
        }

        public string[] GetCoordinates(string position)
        {
            string x = position.Substring(0, 1);
            string y = position.Substring(1, 1);

            if (position.Length == 3)
            {
              y = position.Substring(1, 2);
            }

            return new string[] { x, y};
        }

        private Dictionary<string, string> OrientationArrows()
        {
            return new Dictionary<string, string> { { "NORTH", "↑" }, { "SOUTH", "↓" }, { "WEST", "←" }, { "EAST", "→" } };
        }
    }
}

