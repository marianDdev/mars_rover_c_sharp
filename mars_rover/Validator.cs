using System;
using System.Collections.Generic;
using System.Linq;

namespace mars_rover
{
    public class Validator : LocationsHelper
    {
        public string ValidateOrientation(string orientation)
        {
            List<string> orientations = new List<string> { "NORTH", "SOUTH", "EAST", "WEST" };

            while (String.IsNullOrEmpty(orientation))
            {
                Console.WriteLine("Orientation shouldn't be empty. Please provide an orientation");
                orientation = Console.ReadLine().ToUpper();
            }

            while (!(orientation is string))
            {
                Console.WriteLine("Orientation should be of type string");
                orientation = Console.ReadLine().ToUpper();
            }

            while (!orientations.Contains(orientation.ToUpper()))
            {
                Console.WriteLine($"{orientation} is not a valid orientation. Please provide one of the following: {string.Join(",", orientations)}.");

                orientation = Console.ReadLine().ToUpper();
            }

            return orientation;
        }

        public string ValidatetMoveOnXAxys(string x, string currentPosition)
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
                Console.WriteLine($"{x} is not a valid value. Please provide a letter from A to O.");
                x = Console.ReadLine();
            }

            string currentX = currentCoordinates[0];
            int currentXIndex = Array.IndexOf(Letters, currentX);
            int xIndex = Array.IndexOf(Letters, x);
            int distanceToNextX = Math.Abs(currentXIndex - xIndex);

            while (distanceToNextX > 1)
            {
                Console.WriteLine($"The rover is allowed to move only by one square on X axys, you tried to move it by {distanceToNextX} squares.");
                x = Console.ReadLine();

                while (!availableLetters.Contains(x))
                {
                    Console.WriteLine($"{x} is not a valid value. Please provide a letter from A to O.");
                    x = Console.ReadLine();
                }

                while (String.IsNullOrEmpty(x))
                {
                    Console.WriteLine($"Please provide a value for X axys.");
                    x = Console.ReadLine();
                }

                xIndex = Array.IndexOf(Letters, x);
                distanceToNextX = Math.Abs(currentXIndex - xIndex);
            }

            return x;
        }

        public string ValidatetMoveOnYAxys(string y, string currentPosition)
        {
            string[] currentCoordinates = GetCoordinates(currentPosition);

            while (!int.TryParse(y, out _))
            {
                Console.WriteLine($"{y} is not a number. Please provide a number.");
                y = Console.ReadLine();
            } 
            
            int yToInt = Int16.Parse(y);

            Console.WriteLine($"y to int is {yToInt}");

            while (yToInt < 1 || yToInt > 15)
            {
                Console.WriteLine($"{y} is not a valid number. Please provide a number from 1 to 15.");
                y = Console.ReadLine();
            }

            int currentY = Int16.Parse(currentCoordinates[1]);
            int distanceToNextY = Math.Abs(currentY - yToInt);

            while (distanceToNextY > 1)
            {
                Console.WriteLine($"The rover is allowed to move only by one square on Y axys, you tried to move it by {distanceToNextY} squares.");
                y = Console.ReadLine();
                yToInt = Int16.Parse(y);
                distanceToNextY = Math.Abs(currentY - yToInt);
            }

            return y;
            
        }

        public Dictionary<string, string> ValidateNextAvailableMove(string currentPosition, string orientation)
        {
            string nextMove = "";
            string newOrientation = orientation;
            string newPosition = currentPosition;
            string[] currentCoordinates = GetCoordinates(currentPosition);

            string x = currentCoordinates[0];
            int xIndex = Array.IndexOf(Letters, x);

            int y = Int16.Parse(currentCoordinates[1]);

            if (orientation == "NORTH")
            {
                if (y == 1)
                {
                    nextMove = String.Concat(x, y);
                    Console.WriteLine($"Your position is {nextMove}, but you can not go further NORTH. Enter a new orientation.");

                    newOrientation = Console.ReadLine().ToUpper();
                    newOrientation = ValidateOrientation(newOrientation).ToUpper();

                    while (newOrientation == orientation)
                    {
                        Console.WriteLine("Enter a different orientation than NORTH.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    while (newOrientation == "WEST" && x == "A")
                    {
                        Console.WriteLine("You are at the limit of NORTH and WEST, choose other orientation than NORTH or WEST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    while (newOrientation == "EAST" && x == Letters.Last())
                    {
                        Console.WriteLine("You are at the limit of NORTH and EAST, choose other orientation than NORTH or EAST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    Console.WriteLine("Enter a value for X axys");
                    x = Console.ReadLine().ToUpper();
                    x= ValidatetMoveOnXAxys(x, currentPosition).ToUpper();

                    xIndex = Array.IndexOf(Letters, x);

                    Console.WriteLine("Enter a value for Y axys");
                    string yAsString = Console.ReadLine();
                    yAsString = ValidatetMoveOnYAxys(yAsString, currentPosition);
                    y = Int16.Parse(yAsString);

                    newPosition = String.Concat(x, y);

                    string nextX = x;

                    if (newOrientation == "EAST")
                    {
                        nextX = Letters[xIndex + 1];
                    }

                    if (newOrientation == "WEST")
                    {
                        nextX = Letters[xIndex - 1];
                    }

                    if (newOrientation == "SOUTH")
                    {
                        y++;
                    }

                    nextMove = String.Concat(nextX, y);
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
                    Console.WriteLine($"Your position is {nextMove}, but You can not go further south. Enter a new orientation.");

                    newOrientation = Console.ReadLine();
                    newOrientation = ValidateOrientation(newOrientation);



                    Console.WriteLine("Enter a value for X axys");
                    x = Console.ReadLine().ToUpper();
                    x = ValidatetMoveOnXAxys(x, currentPosition);

                    Console.WriteLine("Enter a value for Y axys");
                    string yAsString = Console.ReadLine();
                    yAsString = ValidatetMoveOnYAxys(yAsString, currentPosition);

                    y = Int16.Parse(yAsString);

                    while (y == 15)
                    {
                        Console.WriteLine("Enter a value different than 15 for Y axys");
                        yAsString = Console.ReadLine();
                        yAsString = ValidatetMoveOnYAxys(yAsString, currentPosition);
                        y = Int16.Parse(yAsString);
                    }

                    newPosition = String.Concat(x, y);

                    nextMove = String.Concat(x, y);
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
                    Console.WriteLine($"Your position is {nextMove}, but You can not go further west. Enter a new orientation.");

                    newOrientation = Console.ReadLine();
                    newOrientation = ValidateOrientation(newOrientation).ToUpper();

                    while (newOrientation == orientation)
                    {
                        Console.WriteLine("Enter a different orientation than WEST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    while (newOrientation == "NORTH" && y == 1)
                    {
                        Console.WriteLine("You are at the limit of NORTH and WEST, choose other orientation than NORTH or WEST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    while (newOrientation == "SOUTH" && y == 15)
                    {
                        Console.WriteLine("You are at the limit of SOUTH and WEST, choose other orientation than SOUTH or WEST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    Console.WriteLine("Enter a value for X axys");
                    x = Console.ReadLine().ToUpper();
                    x = ValidatetMoveOnXAxys(x, currentPosition).ToUpper();
                    xIndex = Array.IndexOf(Letters, x);

                    Console.WriteLine("Enter a value for Y axys");
                    string yAsString = Console.ReadLine();
                    yAsString = ValidatetMoveOnYAxys(yAsString, currentPosition).ToUpper();

                    y = Int16.Parse(yAsString);
                    string nextX = x;

                    newPosition = String.Concat(x, y);

                    if (newOrientation == "EAST")
                    {
                        nextX = Letters[xIndex + 1];
                    }

                    if (newOrientation == "SOUTH")
                    {
                        y++;
                    }

                    if (newOrientation == "NORTH")
                    {
                        y--;
                    }

                    nextMove = String.Concat(nextX, y);
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
                    Console.WriteLine($"Your position is {nextMove}, but You can not go further east. Enter a new orientation.");

                    newOrientation = Console.ReadLine();
                    newOrientation = ValidateOrientation(newOrientation).ToUpper();

                    while (newOrientation == orientation)
                    {
                        Console.WriteLine("Enter a different orientation than EAST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    while (newOrientation == "NORTH" && y == 1)
                    {
                        Console.WriteLine("You are at the limit of NORTH and EAST, choose other orientation than NORTH or EAST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    while (newOrientation == "SOUTH" && y == 15)
                    {
                        Console.WriteLine("You are at the limit of SOUTH and EAST, choose other orientation than SOUTH or EAST.");
                        newOrientation = Console.ReadLine();
                        newOrientation = ValidateOrientation(newOrientation).ToUpper();
                    }

                    Console.WriteLine("Enter a value for X axys");
                    x = Console.ReadLine().ToUpper();
                    x = ValidatetMoveOnXAxys(x, currentPosition).ToUpper();
                    xIndex = Array.IndexOf(Letters, x);

                    Console.WriteLine("Enter a value for Y axys");
                    string yAsString = Console.ReadLine();
                    yAsString = ValidatetMoveOnYAxys(yAsString, currentPosition).ToUpper();

                    y = Int16.Parse(yAsString);
                    string nextX = x;

                    newPosition = String.Concat(x, y);

                    if (newOrientation == "WEST")
                    {
                        nextX = Letters[xIndex - 1];
                    }

                    if (newOrientation == "NORTH")
                    {
                        y--;
                    }

                    if (newOrientation == "SOUTH")
                    {
                        y++;
                    }

                    nextMove = String.Concat(nextX, y);
                }
                else
                {
                    string nextX = Letters[xIndex + 1];
                    nextMove = String.Concat(nextX, y);
                }
            }

            string askDetails = "no";

            if (newPosition == currentPosition)
            {
                askDetails = "yes";
            }

            return new Dictionary<string, string> { { "current_position", newPosition }, { "new_orientation", newOrientation }, { "next_move", nextMove }, { "ask_details", askDetails } };
        }
    }
}

