using System.ComponentModel;

namespace Bowling.src.Categories
{
    public class GutterBall : ICategory
    {
        public int Pins => 0;

        public int GetPins(string roll)
        {
            return Pins;
        }
    }
}