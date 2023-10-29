namespace Bowling.src
{
    #pragma warning disable CS8602 // Dereference of a possibly null reference.
    public class BowlingGame
    {
        public int GameScore(string frame)
        {
            var parse = new Parse();
            var game = parse.Parser(frame);

            if (game[0].Roll2 == null)
            {
                return 300;
            }

            var score = game.Sum(rolls => rolls.Roll1.Pins + rolls.Roll2.Pins);

            return score;
        }
    }
}