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

            var sum = 0;

            foreach (var item in frame)
            {
                sum += symbolMapper[item[0]] + symbolMapper[item[1]];
            }

            return sum;
        }
    }
}