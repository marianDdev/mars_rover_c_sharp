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
            Rover r = new Rover(helper.GetRandomLocation(), helper.GetRandomOrientation());

            r.ShowNextAvailableMove();

            Console.WriteLine("Enter ORIENTATION");
            string orientation = Console.ReadLine().ToUpper();
            validator.ValidateOrientation(orientation);

            //r.ChangeOrientation(orientation);

            r.ShowNextAvailableMove();

            Console.WriteLine("Enter next X axys position.");
            string x = Console.ReadLine().ToUpper();
            validator.ValidatetMoveOnXAxys(x, r.CurrentPosition);

            Console.WriteLine("Enter next Y axys position.");
            string y = Console.ReadLine().ToUpper();
            validator.ValidatetMoveOnYAxys(y, r.CurrentPosition);

            r.Move(x, y);

            m.PrintSurface(r.CurrentPosition, r.Orientation);
        }
    }
}

