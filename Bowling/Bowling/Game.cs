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
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 }
            };

            var sum = frame.Sum(roll => symbolMapper[roll[0]] + symbolMapper[roll[1]]);

            return sum;
        }
    }
}