namespace Bowling.src.Categories
{
    public class Normal : ICategory
    {
        private string rollPins;

        public Normal(string rollPins)
        {
            this.rollPins = rollPins;
        }

        public int Pins => int.Parse(rollPins);

        public int GetPins(string roll)
        {
            return Pins;
        }
    }
}