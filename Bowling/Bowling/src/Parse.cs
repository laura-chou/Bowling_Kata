﻿using Bowling.src.Categories;

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
                return new Rolls
                {
                    Roll1 = GetRoll(rolls, 0),
                    Roll2 = GetRoll(rolls, 1),
                    Roll3 = GetRoll(rolls, 2)
                };
            }).ToList();
            return new List<Rolls>(rolls);
        }

        private int GetPins(string roll)
        {
            var symbolMapper = new Dictionary<string, ICategory>
            {
                { "-", new GutterBall()},
                { "X", new Strike()},
                { "/", new Spare()}
            };
            ICategory category = symbolMapper.ContainsKey(roll) ? symbolMapper[roll] : new Normal();
            return category.GetPins(roll);
        }

        private Roll? GetRoll(string rolls, int index)
        {
            if (index < rolls.Length)
            {
                return new Roll { Pins = GetPins(rolls[index].ToString()) };
            }
            return null;
        }
    }
}