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
                { '1', 1 }
            };

            var sum = frame.Sum(row => symbolMapper[row[0]] + symbolMapper[row[1]]);

            return sum;
        }
    }
}