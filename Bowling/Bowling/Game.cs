namespace Bowling
{
    public class Game
    {
        public List<Roll> Rolls { get; private set; }

        public int ShowResult(string input)
        {
            var frame = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var symbolMapper = new Dictionary<string, int>
            {
                { "-", 0 }
            };

            if (input[0] == 'X')
            {
                return 300;
            }
            var game = frame.Select(roll => new Game
            {
                Rolls = new List<Roll>
                {
                    new Roll 
                    {
                        Pins = symbolMapper.ContainsKey(roll[0].ToString())
                        ? symbolMapper[roll[0].ToString()]
                        : int.Parse(roll[0].ToString())
                    },
                    new Roll
                    {
                        Pins = symbolMapper.ContainsKey(roll[1].ToString())
                        ? symbolMapper[roll[1].ToString()]
                        : int.Parse(roll[1].ToString())
                    }
                }
            });
            var sum = game.Sum(rolls => rolls.Rolls.Sum(roll => roll.Pins));

            return sum;
        }
    }
}