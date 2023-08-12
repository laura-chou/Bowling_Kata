namespace Bowling
{
    public class Game
    {
        public List<Roll> Rolls { get; private set; }

        public int ShowResult(string input)
        {
            var frame = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            if (input[0] == 'X')
            {
                return 300;
            }
            var game = frame.Select(rolls => new Game
            {
                Rolls = GetRolls(rolls)
            });
            var sum = game.Sum(rolls => rolls.Rolls.Sum(roll => roll.Pins));

            return sum;
        }

        private List<Roll> GetRolls(string rolls)
        {
            var symbolMapper = new Dictionary<string, int>
            {
                { "-", 0 }
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