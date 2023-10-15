namespace Bowling
{
    public class Strike : BaseMethod, IType
    {
        private List<Rolls> _game;

        public Strike(List<Rolls> game)
        {
            _game = game;
        }

        public int GetBonus(int index)
        {
            var bonus = 0;
            if (!IsLastRolls(index))
            {
                bonus += _game[index + 1].FirstRoll.Pins;
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                bonus += HaveThisRoll(_game[index + 1].SecondRoll)
                        ? _game[index + 1].SecondRoll.Pins
                        : _game[index + 2].FirstRoll.Pins;
            }
            return bonus;
        }
    }
}