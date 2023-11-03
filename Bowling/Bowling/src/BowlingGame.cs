namespace Bowling.src
{
    #pragma warning disable CS8602 // Dereference of a possibly null reference.
    public class BowlingGame
    {
        public int GameScore(string frame)
        {
            var parse = new Parse();
            var game = parse.Parser(frame);

            var score = 0;
            var index = 0;
            game.ForEach(rolls =>
            {
                score += GetRollPins(rolls.Roll1) + GetRollPins(rolls.Roll2) + GetRollPins(rolls.Roll3);
                if (rolls.Roll2 == null)
                {
                    score += GetStrikeBonus(game, index);
                }
                index++;
            });

            return score;
        }

        private int GetRollPins(Roll? roll)
        {
            return roll != null ? roll.Pins : 0;
        }

        private int GetStrikeBonus(List<Rolls> game, int index)
        {
            int bonus = 0;
            bonus += game[index + 1].Roll1.Pins;
            bonus += game[index + 1].Roll2 == null
                    ? game[index + 2].Roll1.Pins
                    : game[index + 1].Roll2.Pins;
            return bonus;
        }
    }
}