namespace Bowling.src.Categories
{
    public class Spare : ICategory
    {
        public int Pins => 2;

        public int GetPins(string roll)
        {
            return Pins;
        }
    }
}