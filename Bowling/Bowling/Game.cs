using System.ComponentModel.Design;

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
            int index = 0;
            foreach (var rolls in game)
            {
                foreach(var roll in rolls.Rolls)
                {
                    var totalRoll = rolls.Rolls.Count;
                    score += roll.Pins;
                    // 如果只有一球而且是Strike
                    if (totalRoll == 1 && roll.Pins == 10 && index != 9)
                    {
                        // 加上下兩球
                        score += game[index + 1].Rolls[0].Pins;
                        score += (index != 8)
                                ? game[index + 2].Rolls[0].Pins
                                : game[index + 1].Rolls[1].Pins;
                    }
                }
                index++;
            }

            return score;
        }

        private List<Roll> GetRolls(string rolls)
        {
            var symbolMapper = new Dictionary<string, int>
            {
                { "-", 0 },
                { "X", 10}
            };

            var rollList = rolls.Select(roll => new Roll
            {
                Pins = symbolMapper.ContainsKey(roll.ToString())
                        ? symbolMapper[roll.ToString()]
                        : int.Parse(roll.ToString())
            });

            return new List<Roll>(rollList);
        }
    }
}