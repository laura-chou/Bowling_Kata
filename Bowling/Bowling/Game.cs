namespace Bowling
{
    public class Game
    {
        public int ShowResult(string input)
        {
            var frame = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (input[0] == '1')
            {
                var sum = 0;
                foreach (var item in frame)
                {
                    var row1 = int.Parse(item[0].ToString());
                    var row2 = int.Parse(item[1].ToString());

                    sum += row1 + row2;
                }
                return sum;
            }

            return 0;
        }
    }
}