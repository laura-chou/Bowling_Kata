namespace Bowling
{
    public class Parse
    {
        public List<Rolls> Parser(string frame)
        {
            var game = frame.Split(' ').ToList();

            
            var rolls = game.Select(rolls => new Rolls
            {
                #pragma warning disable CS8601 // Possible null reference assignment.
                FirstRoll = GetRoll(rolls, 0),
                SecondRoll = GetRoll(rolls, 1),
                ThirdRoll = GetRoll(rolls, 2)
            });

            return new List<Rolls>(rolls);
        }

        private Roll? GetRoll(string rolls, int index)
        {
            if (rolls.Length > index)
            {
                if (GetPins(rolls[index]) == 99)
                {
                    return new Roll { Pins = 10 - GetPins(rolls[0]) };
                }
                return new Roll { Pins = GetPins(rolls[index]) };
            }

            return null;
        }

        private int GetPins(char roll)
        {
            var symbolMapper = new Dictionary<char, int>
            {
                { '-', 0 },
                { 'X', 10 },
                { '/', 99 },
            };

            return symbolMapper.ContainsKey(roll)
                ? symbolMapper[roll]
                : int.Parse(roll.ToString());
        }
    }
}