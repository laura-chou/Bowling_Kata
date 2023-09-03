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

            return CalculateScore(game);
        }

        private int CalculateScore(List<Rolls> game)
        {
            var score = 0;
            var index = 0;

            game.ForEach(rolls =>
            {
                score += GetRollPins(rolls.Roll1) + GetRollPins(rolls.Roll2)
                        + (index < 9 ? GetBonus(game, index) : GetRollPins(rolls.Roll3));
                index++;
            });

            return score;
        }

        private int ConvertRollPins(string rolls, int index)
        {
            var symbolMapper = new Dictionary<string, int>
            {
                { "-", 0 },
                { "X", 10 },
                { "/", 99 }
            };

            var str = rolls[index].ToString();

            return symbolMapper.ContainsKey(str)
                    ? symbolMapper[str]
                    : int.Parse(str);
        }

        private int GetBonus(List<Rolls> game, int index)
        {
            var bonus = 0;

            // 如果是 Strike
            if (game[index].Roll2 == null)
            {
                // 加上下兩球
                bonus += GetRollPins(game[index + 1].Roll1);
                bonus += game[index + 1].Roll2 == null
                    ? GetRollPins(game[index + 2].Roll1)
                    : GetRollPins(game[index + 1].Roll2);
            }
            else
            {
                // 如果是 Spare
                if (GetRollPins(game[index].Roll1) + GetRollPins(game[index].Roll2) == 10)
                {
                    bonus += GetRollPins(game[index + 1].Roll1);
                }
            }

            return bonus;
        }

        private Roll? GetRoll(string rolls, int roll)
        {
            if (rolls.Length >= roll)
            {
                var pins = ConvertRollPins(rolls, roll - 1);

                pins = pins == 99 ? 10 - ConvertRollPins(rolls, 0) : pins;

                return new Roll { Pins = pins };
            }

            return null;
        }
        private int GetRollPins(Roll? roll)
        {
            return roll != null ? roll.Pins : 0;
        }
    }
}