﻿namespace Bowling
{
    public class Strike : ICategory
    {
        public int Pins => 10;

        public int GetPins(string roll)
        {
            return Pins;
        }
    }
}