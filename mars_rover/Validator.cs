using System;
using System.Linq;
using System.Collections.Generic;

namespace mars_rover
{
    public class Validator : LocationsHelper
    {
        public void ValidatetMoveOnXAxys(string x)
        {
            
            if (!String.IsNullOrEmpty(x))
            {
                Console.WriteLine($"Please provide a value for X axys.");
            }

            string availableLetters = Letters.ToString();

            if (!availableLetters.Contains(x))
            {
                Console.WriteLine($"{x} is out of allowed range. Please provide a letter from A to O.");
            }
        }

        public void ValidatetMoveOnYAxys(string y)
        {
          
            if (!int.TryParse(y, out _))
            {
                Console.WriteLine($"{y} is not a number. Please provide a number.");
            } else
            {
                int yToInt = Int16.Parse(y);

                if (yToInt < 1 || yToInt > 15)
                {
                    Console.WriteLine($"{y} is not a valid number. Please provide a number from 1 to 15.");
                }
            }
            
        }

        public void ValidateOrientation(string orientation)
        {
            List<string> orientations = new List<string> { "NORTH", "SOUTH", "EAST", "WEST" };

            if (String.IsNullOrEmpty(orientation)) {
                Console.WriteLine("Please provide an orientation");
            }

            if (!(orientation is string))
            {
                Console.WriteLine("Orientation should be of type string");
            }

            if (!orientations.Contains(orientation.ToUpper())) {
                Console.WriteLine($"{orientation} is not a valid orientation. Please provide one of the following: {string.Join(",", orientations)}.");
            }
        }
    }
}

