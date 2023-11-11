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
                if (IsStrike(rolls))
                {
                    score += GetStrikeBonus(game, index);
                }
                else
                {
                    if (IsSpare(rolls))
                    {
                        score += GetSpareBonus(game, index);
                    }
                }

                index++;
            });

            return score;
        }

        private int GetRollPins(Roll? roll)
        {
            return roll != null ? roll.Pins : 0;
        }

        private int GetSpareBonus(List<Rolls> game, int index)
        {
            return game[index + 1].Roll1.Pins;
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

        private bool IsSpare(Rolls rolls)
        {
            return rolls.Roll1.Pins + rolls.Roll2.Pins == 10;
        }

        private bool IsStrike(Rolls rolls)
        {
            return rolls.Roll2 == null;
        }
    }
}