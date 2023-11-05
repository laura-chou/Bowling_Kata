namespace Bowling.src.Categories
{
    public class Normal : ICategory
    {
        private readonly string RollPins;

        public Normal(string pins)
        {
            this.RollPins = pins;
        }

        public int GetPins()
        {
            return int.Parse(RollPins);
        }
    }
}