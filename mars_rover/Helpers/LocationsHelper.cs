using System;
using System.Collections.Generic;
using System.Linq;

namespace mars_rover
{
    public class LocationsHelper
    {
        public char[] Letters = "ABCDEFGHIJKLMNO".ToCharArray();

        public string GetRandomLocation()
        {
            Random r = new Random();
            int position = r.Next(1, 15);

            char randomLetter = Letters[position];

            string randomPosition = String.Concat(randomLetter, position);

            Dictionary<string, Object> MarsLocations = Locations();

            string randomLocation = MarsLocations.Where(location => location.Key.Equals(randomPosition)).First().Key;

            return randomLocation;

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

        private Dictionary<string, string> OrientationArrows()
        {
            return new Dictionary<string, string> { { "NORTH", "↑" }, { "SOUTH", "↓" }, { "WEST", "←" }, { "EAST", "→" } };
        }
    }
}

