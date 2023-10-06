using System.Linq;

namespace Bowling
{
    public class Game
    {
        public int ShowResult(string frame)
        {
            var parse = new Parse();
            var game = parse.Parser(frame);

            var score = 0;
            if (game[0].FirstRoll.Pins == 10)
            {
                var index = 0;
                game.ForEach(rolls =>
                {
                    score += GetFirstRollPins(rolls) + GetBonus(game, index) + GetSecondRollPins(rolls) + GetThirdRollPins(rolls);
                    index++;
                });
            }
            else
            {
                game.Sum(rolls => score += GetFirstRollPins(rolls) + GetSecondRollPins(rolls));
            }

            return score;
        }

        private int GetBonus(List<Rolls> game, int index)
        {
            var bonus = 0;
            if (!HaveThisRoll(game[index].SecondRoll))
            {
                bonus += game[index + 1].FirstRoll.Pins;
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                bonus += HaveThisRoll(game[index + 1].SecondRoll) ? game[index + 1].SecondRoll.Pins : game[index + 2].FirstRoll.Pins;
            }
            return bonus;
        }

        private int GetFirstRollPins(Rolls rolls)
        {
            return rolls.FirstRoll.Pins;
        }

        private int GetSecondRollPins(Rolls rolls)
        {
            return HaveThisRoll(rolls.SecondRoll) ? rolls.SecondRoll.Pins : 0;
        }

        private int GetThirdRollPins(Rolls rolls)
        {
            return HaveThisRoll(rolls.ThirdRoll) ? rolls.ThirdRoll.Pins : 0;
        }

        private bool HaveThisRoll(Roll? roll)
        {
            return roll != null;
        }
    }
}