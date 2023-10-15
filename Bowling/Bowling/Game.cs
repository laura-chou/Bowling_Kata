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
            var index = 0;
            game.ForEach(rolls =>
            {
                score += GetFirstRollPins(rolls) + GetSecondRollPins(rolls) + GetThirdRollPins(rolls);
                if (!IsLastRolls(index))
                {
                    if (IsStrike(rolls))
                    {
                        score += GetStrikeBonus(game, index);
                    }
                    if (IsSpare(rolls))
                    {
                        score += GetSpareBonus(game, index);
                    }
                }
                index++;
            });

            return score;
        }

        private bool IsLastRolls(int index)
        {
            return index + 1 == 10;
        }

        private int GetFirstRollPins(Rolls rolls)
        {
            return rolls.FirstRoll.Pins;
        }

        private int GetSecondRollPins(Rolls rolls)
        {
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            return HaveThisRoll(rolls.SecondRoll) ? rolls.SecondRoll.Pins : 0;
        }

        private int GetSpareBonus(List<Rolls> game, int index)
        {
            return game[index + 1].FirstRoll.Pins;
        }

        private int GetStrikeBonus(List<Rolls> game, int index)
        {
            var bonus = 0;
            bonus += game[index + 1].FirstRoll.Pins;
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            bonus += HaveThisRoll(game[index + 1].SecondRoll) ? game[index + 1].SecondRoll.Pins : game[index + 2].FirstRoll.Pins;
            return bonus;
        }

        private int GetThirdRollPins(Rolls rolls)
        {
            return HaveThisRoll(rolls.ThirdRoll) ? rolls.ThirdRoll.Pins : 0;
        }

        private bool HaveThisRoll(Roll? roll)
        {
            return roll != null;
        }

        private bool IsSpare(Rolls rolls)
        {
            return GetFirstRollPins(rolls) != 10 && GetFirstRollPins(rolls) + GetSecondRollPins(rolls) == 10;
        }

        private bool IsStrike(Rolls rolls)
        {
            return !HaveThisRoll(rolls.SecondRoll);
        }
    }
}