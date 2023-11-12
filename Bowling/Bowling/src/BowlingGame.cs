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

                if (!IsTheLastRoll(game, index))
                {
                    score += GetBonus(game, index);
                }

                index++;
            });

            return score;
        }

        private int GetBonus(List<Rolls> game, int index)
        {
            int bonus = 0;
            if (IsStrike(game[index]) || IsSpare(game[index]))
            {
                bonus += game[index + 1].Roll1.Pins;
                if (IsStrike(game[index]))
                {
                    bonus += game[index + 1].Roll2 == null
                            ? game[index + 2].Roll1.Pins
                            : game[index + 1].Roll2.Pins;
                }
            }
            return bonus;
        }

        private bool IsTheLastRoll(List<Rolls> game, int index)
        {
            return index + 1 == game.Count;
        }

        private int GetRollPins(Roll? roll)
        {
            return roll != null ? roll.Pins : 0;
        }

        private bool IsSpare(Rolls rolls)
        {
            return rolls.Roll2 != null
                ? rolls.Roll2.Category == Category.Spare
                : false;
        }

        private bool IsStrike(Rolls rolls)
        {
            return rolls.Roll1.Category == Category.Strike;
        }
    }
}