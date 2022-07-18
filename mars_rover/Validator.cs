using System;
using System.Linq;
using System.Collections.Generic;

namespace mars_rover
{
    public class Validator : LocationsHelper
    {
        public void ValidatetMoveOnXAxys(string x, string currentPosition)
        {
            string[] currentCoordinates = GetCoordinates(currentPosition);

            while (String.IsNullOrEmpty(x))
            {
                Console.WriteLine($"Please provide a value for X axys.");
                x = Console.ReadLine();
            }

            string availableLetters = String.Join("", Letters);

            while (!availableLetters.Contains(x))
            {
                Console.WriteLine($"{x} is out of allowed range. Please provide a letter from A to O.");
                x = Console.ReadLine();
            }

            string currentX = currentCoordinates[0];
            int currentXIndex = Array.IndexOf(Letters, currentX);
            int xIndex = Array.IndexOf(Letters, x);
            int distanceToNextX = Math.Abs(currentXIndex - xIndex);

            while (distanceToNextX > 1)
            {
                Console.WriteLine($"The rover is allowed to move only by one square on X axys, you tried to move it by {distanceToNextX} sqaures.");
            } 
        }

        public void ValidatetMoveOnYAxys(string y, string currentPosition)
        {
            string[] currentCoordinates = GetCoordinates(currentPosition);

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

                int currentY = Int16.Parse(currentCoordinates[1]);
                int distanceToNextY = Math.Abs(currentY - yToInt);

                if (distanceToNextY > 1)
                {
                    Console.WriteLine($"The rover is allowed to move only by one square on Y axys, you tried to move it by {distanceToNextY} squares.");
                }
            }
            
        }

        public void ValidateOrientation(string orientation)
        {
            List<string> orientations = new List<string> { "NORTH", "SOUTH", "EAST", "WEST" };

            while (String.IsNullOrEmpty(orientation)) {
                Console.WriteLine("Orientation shouldn't be empty. Please provide an orientation");
                orientation = Console.ReadLine().ToUpper();
            }

            while (!(orientation is string))
            {
                Console.WriteLine("Orientation should be of type string");
                orientation = Console.ReadLine().ToUpper();
            }

            while (!orientations.Contains(orientation.ToUpper())) {
                Console.WriteLine($"{orientation} is not a valid orientation. Please provide one of the following: {string.Join(",", orientations)}.");

                orientation = Console.ReadLine().ToUpper();
            }
        }

        public string ValidateNextAvailableMove(string currentPosition, string orientation)
        {
            string nextMove = "";
            string[] currentCoordinates = GetCoordinates(currentPosition);

            string x = currentCoordinates[0];
            int xIndex = Array.IndexOf(Letters, x);

            int y = Int16.Parse(currentCoordinates[1]);

            if (orientation == "NORTH")
            {
                if (y == 1)
                {
                    nextMove = String.Concat(x, y);
                    Console.WriteLine("You can not go further north. Consider changing orientation.");
                    x = Console.ReadLine();
                    y = Int16.Parse(Console.ReadLine());
                }
                else
                {
                    int nextY = y - 1;
                    nextMove = String.Concat(x, nextY);
                }
            }

            if (orientation == "SOUTH")
            {
                if (y == 15)
                {
                    nextMove = String.Concat(x, y);
                    Console.WriteLine("You can not go further south. Consider changing orientation.");
                    x = Console.ReadLine();
                    y = Int16.Parse(Console.ReadLine());
                }
                else
                {
                    int nextY = y + 1;
                    nextMove = String.Concat(x, nextY);

                }

            }

            if (orientation == "WEST")
            {
                if (xIndex == 0)
                {
                    nextMove = String.Concat(x, y);
                    Console.WriteLine("You can not go further west. Consider changing orientation.");
                    x = Console.ReadLine();
                    y = Int16.Parse(Console.ReadLine());
                }
                else
                {
                    string nextX = Letters[xIndex - 1];
                    nextMove = String.Concat(nextX, y);
                }
            }

            if (orientation == "EAST")
            {
                if (xIndex == 14)
                {
                    nextMove = String.Concat(x, y);
                    Console.WriteLine("You can not go further east. Consider changing orientation.");
                    x = Console.ReadLine();
                    y = Int16.Parse(Console.ReadLine());
                }
                else
                {
                    string nextX = Letters[xIndex + 1];
                    nextMove = String.Concat(nextX, y);
                }
            }

            return nextMove;
        }
    }
}

