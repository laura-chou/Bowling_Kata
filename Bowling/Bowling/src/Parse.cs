using Bowling.src.Categories;
using System;

namespace Bowling.src
{
    #pragma warning disable CS8601 // Possible null reference assignment.
    public class Parse
    {
        public List<Rolls> Parser(string frame)
        {
            var game = frame.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var rolls = game.Select(rolls =>
            {
                var compareRollCategory = new CompareRollCategory(rolls);
                return new Rolls
                {
                    Roll1 = compareRollCategory.GetRoll(0),
                    Roll2 = compareRollCategory.GetRoll(1),
                    Roll3 = compareRollCategory.GetRoll(2)
                };
            }).ToList();
            return new List<Rolls>(rolls);
        }
    }
}