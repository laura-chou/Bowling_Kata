namespace Bowling
{
    public class Spare : BaseMethod, IType
    {
        private List<Rolls> _game;

        public Spare(List<Rolls> game)
        {
            _game = game;
        }

        public int GetBonus(int index)
        {
            if (!IsLastRolls(index))
            {
                return _game[index + 1].FirstRoll.Pins;
            } 
            return 0;
        }
    }
}