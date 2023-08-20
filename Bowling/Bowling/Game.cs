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
                score += index < 10 ? rolls.Roll1.Pins + (rolls.Roll2 != null ? rolls.Roll2.Pins : 0) + GetBonus(game, index) : rolls.Roll1.Pins + rolls.Roll2.Pins + (rolls.Roll3 != null ? rolls.Roll3.Pins : 0);
                index++;
            });

            return score;
        }

        private int GetBonus(List<Rolls> game, int index)
        {
            var bonus = 0;
            // 如果只有一球而且是Strike
            if (game[index - 1].Roll2 == null)
            {
                // 加上下兩球
                bonus += game[index].Roll1.Pins;
                bonus += game[index].Roll2 == null
                    ? game[index + 1].Roll1.Pins
                    : game[index].Roll2.Pins;
            } 
            else
            {
                // 如果是 Spare
                if (game[index - 1].Roll1.Pins + game[index - 1].Roll2.Pins == 10)
                {
                    bonus += game[index].Roll1.Pins;
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
                    pins = 10 - int.Parse(rolls[0].ToString());
                }

                return new Roll { Pins = pins };
            }

            return null;
        }
    }
}