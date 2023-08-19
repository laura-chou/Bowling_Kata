using System.ComponentModel.Design;
using System.Data.SqlTypes;

namespace Bowling
{
    public class Game
    {
        public List<Roll> Rolls { get; private set; }

        public int ShowResult(string input)
        {
            var frame = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var game = frame.Select(rolls => new Game
            {
                Rolls = GetRolls(rolls)
            }).ToList();

            var sum = CalculateScore(game);

            return sum;
        }

        private int CalculateScore(List<Game> game)
        {
            var score = 0;
            game.ForEach(rolls => rolls.Rolls.ForEach(roll =>
            {
                score += roll.Pins + GetBonus(game, rolls, roll);
            }));

            return score;
        }

        private int GetBonus(List<Game> game, Game rolls, Roll roll)
        {
            var totalRoll = rolls.Rolls.Count;
            var index = 0;
            var score = 0;

            // 如果只有一球而且是Strike
            if (totalRoll == 1 && roll.Pins == 10 && index != 9)
            {
                // 加上下兩球
                score += game[index + 1].Rolls[0].Pins;
                score += (index != 8)
                        ? game[index + 2].Rolls[0].Pins
                        : game[index + 1].Rolls[1].Pins;
            }
            // 如果是 Spare
            if (totalRoll == 2 && rolls.Rolls[1].Pins == roll.Pins && rolls.Rolls.Sum(roll => roll.Pins) == 10)
            {
                score += game[index + 1].Rolls[0].Pins;
            }

            index++;
            
            return score;
        }

        private List<Roll> GetRolls(string rolls)
        {
            var symbolMapper = new Dictionary<string, int>
            {
                { "-", 0 },
                { "X", 10 },
                { "/", 10 }
            };

            var rollList = rolls.Select(roll => new Roll
            {
                Pins = symbolMapper.ContainsKey(roll.ToString())
                        ? symbolMapper[roll.ToString()]
                        : int.Parse(roll.ToString())
            }).ToList();

            if (rollList.Sum(roll => roll.Pins) > 10 && rollList.Count == 2)
            {
                rollList[1].Pins = rollList[1].Pins - rollList[0].Pins;
            }
            
            return new List<Roll>(rollList);
        }
    }
}