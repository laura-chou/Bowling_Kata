namespace Bowling
{
    public class Game
    {
        public int ShowResult(string frame)
        {
            var parse = new Parse();
            var game = parse.Parser(frame);

            var score = 0;
            if (game[0].FirstRoll.Pins == 10)
            {
                score = 300;
            }
            else
            {
                game.Sum(rolls => score += rolls.FirstRoll.Pins + rolls.SecondRoll.Pins);
            }

            return score;
        }
    }
}