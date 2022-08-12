using System;
using System.Collections.Generic;

namespace mars_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationsHelper helper = new LocationsHelper();
            Validator validator = new Validator();
            Mars m = new Mars();
            //Rover r = new Rover(helper.GetRandomLocation(), helper.GetRandomOrientation());
            Rover r = new Rover("D10", "NORTH");

            Dictionary<string, string> PositionData = r.ShowNextAvailableMove();

            if (PositionData["ask_details"] == "no")
            {
                m.PrintSurface(r.CurrentPosition, r.Orientation);
            } else
            {
             Console.WriteLine($"Your current position id {r.CurrentPosition} and your current orientation is  {r.Orientation}.");
             Console.WriteLine("Enter new orientation");
             string orientation = Console.ReadLine().ToUpper();

             orientation = validator.ValidateOrientation(orientation).ToUpper();

             r.ChangeOrientation(orientation);

             Console.WriteLine("Enter next X axys position.");
             string x = Console.ReadLine().ToUpper();
             x= validator.ValidatetMoveOnXAxys(x, r.CurrentPosition).ToUpper();

             Console.WriteLine("Enter next Y axys position.");
             string y = Console.ReadLine().ToUpper();
             y = validator.ValidatetMoveOnYAxys(y, r.CurrentPosition);

             r.ShowNextAvailableMove();

             r.Move(x, y);

             m.PrintSurface(r.CurrentPosition, r.Orientation);
            }
        }
    }
}

