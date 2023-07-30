namespace Bowling
{
    public class Game
    {
        public int ShowResult(string input)
        {
            var frame = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var symbolMapper = new Dictionary<char, int>
            {
                { '-', 0 },
                { '1', 1 },
                { '9', 9 }
            };

            var sum = frame.Sum(roll => symbolMapper[roll[0]] + symbolMapper[roll[1]]);

            return sum;
        }
    }
}