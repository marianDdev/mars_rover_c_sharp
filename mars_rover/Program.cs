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
            string randomLocation = helper.GetRandomLocation();

            Mars m = new Mars();
            Rover r = new Rover(randomLocation, "NORTH");

            Console.WriteLine("To which position should the rover move on X axis?");
            string x = Console.ReadLine().ToUpper();
            validator.ValidatetMoveOnXAxys(x);

            Console.WriteLine("To which position should the rover move on Y axis?");
            string y = Console.ReadLine();
            validator.ValidatetMoveOnYAxys(y);

            r.Move(x, y);

            Console.WriteLine("To which orientation should the rover face?");
            string orientation = Console.ReadLine().ToUpper();
            validator.ValidateOrientation(orientation);

            r.ChangeOrientation(orientation);

            m.PrintLocationsChart(r.CurrentPosition, r.Orientation);
        }
    }
}

