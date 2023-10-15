using System;
using System.Linq;

namespace Bowling
{
    public class Game : BaseMethod
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
                
                IType type = new Gutter();
                if (IsStrike(rolls))
                {
                    type = new Strike(game);
                }
                if (IsSpare(rolls))
                {
                    type = new Spare(game);
                }
                score += type.GetBonus(index);
                
                index++;
            });

            return score;
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

        private int GetThirdRollPins(Rolls rolls)
        {
            return HaveThisRoll(rolls.ThirdRoll) ? rolls.ThirdRoll.Pins : 0;
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