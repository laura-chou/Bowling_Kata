using System.ComponentModel.Design;
using System.Data.SqlTypes;
using static System.Formats.Asn1.AsnWriter;

namespace Bowling
{
    public class Game
    {
        public int ShowResult(string input)
        {
            var frame = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var game = frame.Select(rolls => new Rolls
            {
                Roll1 = GetRoll(rolls, 1),
                Roll2 = GetRoll(rolls, 2),
                Roll3 = GetRoll(rolls, 3)
            }).ToList();

            var sum = CalculateScore(game);

            return sum;
        }

        private int CalculateScore(List<Rolls> game)
        {
            var score = 0;
            var index = 1;

            game.ForEach(rolls =>
            {
                score += GetRollPins(rolls.Roll1) + GetRollPins(rolls.Roll2) 
                        + (index < 10 ? GetBonus(game, index) : GetRollPins(rolls.Roll3));
                index++;
            });

            return score;
        }

        private int GetRollPins(Roll? roll)
        {
            return roll != null ? roll.Pins : 0;
        }

        private int GetBonus(List<Rolls> game, int index)
        {
            var bonus = 0;
            // 如果只有一球而且是Strike
            if (game[index - 1].Roll2 == null)
            {
                // 加上下兩球
                bonus += GetRollPins(game[index].Roll1);
                bonus += game[index].Roll2 == null
                    ? GetRollPins(game[index + 1].Roll1)
                    : GetRollPins(game[index].Roll2);
            } 
            else
            {
                // 如果是 Spare
                if (GetRollPins(game[index - 1].Roll1) + GetRollPins(game[index - 1].Roll2) == 10)
                {
                    bonus += GetRollPins(game[index].Roll1);
                }
            }

            return bonus;
        }

        private Roll? GetRoll(string rolls, int roll)
        {
            var symbolMapper = new Dictionary<string, int>
            {
                { "-", 0 },
                { "X", 10 },
                { "/", 99 }
            };
            
            if (rolls.Length >= roll)
            {
                var pins = symbolMapper.ContainsKey(rolls[roll - 1].ToString())
                        ? symbolMapper[rolls[roll - 1].ToString()]
                        : int.Parse(rolls[roll - 1].ToString());

                if (pins == 99)
                {
                    pins = 10 - 
                        (symbolMapper.ContainsKey(rolls[0].ToString())
                        ? symbolMapper[rolls[0].ToString()]
                        : int.Parse(rolls[0].ToString()));

                }

                return new Roll { Pins = pins };
            }

            return null;
        }
    }
}