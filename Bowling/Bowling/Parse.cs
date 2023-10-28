namespace Bowling
{
    public class Parse
    {
        public List<Rolls> Parser(string frame)
        {
            var game = frame.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var rolls = game.Select(rolls =>
            {
                return new Rolls
                {
                    Roll1 = new Roll { Pins = GetPins(rolls[0].ToString()) },
                    Roll2 = new Roll { Pins = GetPins(rolls[1].ToString()) }
                };
            }).ToList();
            return new List<Rolls>(rolls);
        }

        private int GetPins(string roll)
        {
            var symbolMapper = new Dictionary<string, ICategory>
            {
                { "-", new GutterBall()}
            };
            ICategory category = symbolMapper.ContainsKey(roll) ? symbolMapper[roll] : new Normal(roll);
            return category.GetPins(roll);
        }
    }
}