using System;
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


        public void ShowNextAvailableMove()
        {
            ValidateOrientation(Orientation);
            Console.WriteLine($"Your current position is {CurrentPosition} and you are heading {Orientation}. Your next available move is {ValidateNextAvailableMove(CurrentPosition, Orientation)}");
        }
    }
}

