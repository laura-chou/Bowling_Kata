namespace Bowling
{
    public class BowlingGame
    {
        public int GameScore(string frame)
        {
            var parse = new Parse();
            var game = parse.Parser(frame);
            
            var score = game.Sum(rolls => rolls.Roll1.Pins + rolls.Roll2.Pins);
            
            return score;
        }
    }
}