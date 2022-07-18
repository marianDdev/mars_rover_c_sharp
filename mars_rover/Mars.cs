using System;
using System.Collections.Generic;
using System.Linq;
using mars_rover.Interfaces;

namespace mars_rover
{
    public class Mars: LocationsHelper, IMarsInterface
    {

        public void PrintSurface(string position, string orientation)
        {
            Dictionary<string, Object> MarsLocations = LocationsWithRoverPosition(position, orientation);

            foreach (KeyValuePair<string, Object> location in MarsLocations)
            {
                Console.Write(location.Value + " ");
                if (location.Key.Contains("O"))
                {
                    Console.WriteLine("");
                }
            }
        }
       
    }
}

