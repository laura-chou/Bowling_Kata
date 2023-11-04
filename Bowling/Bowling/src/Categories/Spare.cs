namespace Bowling.src.Categories
{
    public class Spare : ICategory
    {
        public int GetPins(string roll)
        {
            return 2;
        }
    }
}