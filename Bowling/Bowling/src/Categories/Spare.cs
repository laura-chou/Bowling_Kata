namespace Bowling.src.Categories
{
    public class Spare : ICategory
    {
        private string FirstRollPins;

        public Spare(string pins)
        {
            this.FirstRollPins = pins;
        }

        public int GetPins(string roll)
        {
            return 10 -  int.Parse(FirstRollPins);
        }

    }
}