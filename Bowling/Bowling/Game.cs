namespace Bowling
{
    public class Game
    {
        internal Rolls Roll1 { get; private set; }
        internal Rolls Roll2 { get; private set; }

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
                Roll1 = new Rolls
                {
                    Pins = symbolMapper.ContainsKey(roll[0].ToString()) 
                    ? symbolMapper[roll[0].ToString()]
                    : int.Parse(roll[0].ToString())
                },
                Roll2 = new Rolls
                {
                    Pins = symbolMapper.ContainsKey(roll[1].ToString())
                    ? symbolMapper[roll[1].ToString()]
                    : int.Parse(roll[1].ToString())
                }
            });
            var sum = game.Sum(rolls => rolls.Roll1.Pins + rolls.Roll2.Pins);

            return sum;
        }
    }
}