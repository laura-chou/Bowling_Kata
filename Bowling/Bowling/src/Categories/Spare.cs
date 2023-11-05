namespace Bowling.src.Categories
{
    public class Spare : ICategory
    {
        private readonly string FirstRollPins;

        public Spare(string pins)
        {
            this.FirstRollPins = pins;
        }

        public int GetPins()
        {
            return 10 -  int.Parse(FirstRollPins);
        }

    }
}