namespace Bowling
{
    public class Normal : ICategory
    {
        private string rollPins;

        public Normal(string rollPins)
        {
            this.rollPins = rollPins;
        }

        public string Symbol => rollPins;

        public int Pins => int.Parse(rollPins);

        public int GetPins(string roll)
        {
            return Pins;
        }
    }
}