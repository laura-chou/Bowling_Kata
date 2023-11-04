namespace Bowling.src.Categories
{
    public class Strike : ICategory
    {
        public int GetPins(string roll)
        {
            return 10;
        }
    }
}