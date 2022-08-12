using System;
using System.Collections.Generic;
using mars_rover.Interfaces;

namespace mars_rover
{
    public class Rover : Validator, IRoverInterface
    {
        public string CurrentPosition
        { get; private set; }

        public string Orientation
        { get; private set; }

        public Rover(string currentPosition, string orientation)
        {
            CurrentPosition = currentPosition;
            Orientation = orientation;
        }

        public void ChangeOrientation(string orientation)
        {
            Orientation = orientation;
        }

        public void Move(string x, string y)
        {
            
            CurrentPosition = String.Concat(x, y);
        }

        public Dictionary<string, string> ShowNextAvailableMove()
        {
            ValidateOrientation(Orientation);
            Dictionary<string, string> PositionData = ValidateNextAvailableMove(CurrentPosition, Orientation);
            CurrentPosition = PositionData["current_position"];
            Orientation = PositionData["new_orientation"];

            return PositionData;
        }
    }
}

