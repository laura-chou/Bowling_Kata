namespace Bowling.src.Categories
{
    public class Normal : ICategory
    {
        public int GetPins(string roll)
        {
            return int.Parse(roll);
        }
    }
}