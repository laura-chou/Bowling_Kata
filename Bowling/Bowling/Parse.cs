namespace Bowling
{
    public class Parse
    {
        public List<Rolls> Parser(string frame)
        {
            var game = frame.Split(' ').ToList();

            var symbolMapper = new Dictionary<char, int>
            {
                { '-', 0 }
            };
            var rolls = game.Select(rolls => new Rolls
            {
                FirstRoll = new Roll { Pins = symbolMapper[rolls[0]] },
                SecondRoll = new Roll { Pins = symbolMapper[rolls[1]] }
            });

            return new List<Rolls>(rolls);
        }
    }
}