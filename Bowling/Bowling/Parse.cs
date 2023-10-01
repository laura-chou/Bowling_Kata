namespace Bowling
{
    public class Parse
    {
        public List<Rolls> Parser(string frame)
        {
            var game = frame.Split(' ').ToList();

            var rolls = game.Select(rolls => new Rolls
            {
                FirstRoll = new Roll { Pins = GetPins(rolls[0]) },
                SecondRoll = new Roll { Pins = GetPins(rolls[1]) }
            });

            return new List<Rolls>(rolls);
        }

        private int GetPins(char roll)
        {
            var symbolMapper = new Dictionary<char, int>
            {
                { '-', 0 }
            };

            return symbolMapper.ContainsKey(roll)
                ? symbolMapper[roll]
                : int.Parse(roll.ToString());
        }
    }
}